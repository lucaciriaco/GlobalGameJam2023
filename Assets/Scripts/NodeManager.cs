using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    public List<PickUp> PickUps = new List<PickUp>();
    public List<GameObject> Nodes;
    public int CuantityOfNodes;
    public Transform LastNode;


    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _node;
    [SerializeField] private GameObject _level;
    [SerializeField] private LineRenderer _line;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float _distance;

    private List<RaycastHit2D> ray = new List<RaycastHit2D>();
    
    private void Start()
    {
         FindObjectsOfType<BigNode>().ToList().ForEach(x =>
        {
            x.OnPlayerEnter += SpawnBigNode;
        });

        FindObjectsOfType<PickUp>().ToList().ForEach(x =>
        {
            x.OnPlayerPickUp+= PlayerPickedUp;
        });
    }
   
    private void PlayerPickedUp(PickUp pickUp)
    {
        SoundManager.instance.audioData.PlayOneShot(SoundManager.instance.PickItem);
        PickUps.Add(pickUp);
        pickUp.AddCuantityOfNodes();
        CuantityOfNodes++;
    }

    void Update()
    {
        var result = Physics2D.Linecast(_player.transform.position, LastNode.transform.position, ground);
        if (result.collider == null)
        {
            return;
        }
        if(result.collider.GetComponent<Node>() != null)
        {
            DrawLine();
            if (Input.GetKeyDown(KeyCode.Joystick1Button1) == true && CuantityOfNodes >= 0)
            {
                SpawnNode();
                SoundManager.instance.audioData.PlayOneShot(SoundManager.instance.PlaceNode);
            }
        }
        else
        {
            _line.enabled = false;
        }
        ReturnLastNode();
    }

    private void ReturnLastNode()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button4) == true && LastNode != null && !LastNode.GetComponent<Node>().BigNode)
        {
            _player.position = LastNode.position;
            LastNode.GetComponent<Node>().PickUps.ForEach(pickup => {
                pickup.SubstractCuantityOfNodes();
                CuantityOfNodes--;
            });
            SoundManager.instance.audioData.PlayOneShot(SoundManager.instance.DeleteNode);
            Nodes.Remove(LastNode.gameObject);
            var lastReference = LastNode.gameObject;
            LastNode = LastNode.gameObject.GetComponent<Node>()._lastNode;
            Destroy(lastReference);
            CuantityOfNodes++;
        }
    }

    private void SpawnNode()
    {
        var instance = Instantiate(_node, _player.position, Quaternion.identity).transform;
        LastNode.GetComponent<Node>().PickUps = PickUps;
        instance.GetComponent<Node>().Init(LastNode);
        LastNode = instance;
        Nodes.Add(LastNode.gameObject);
        CuantityOfNodes--;
        PickUps = new List<PickUp>();
    }

    private void SpawnBigNode()
    {
        var instance = Instantiate(_node, _player.position, Quaternion.identity).transform;
        instance.GetComponent<Node>().Init(LastNode, true);
        LastNode = instance;
        Nodes = new List<GameObject>();

    }

    private void DrawLine()
    {
        _line.enabled = true;
        _line.SetPosition(0, _player.transform.position);
        _line.SetPosition(1, LastNode.transform.position);
    }

    private float GetDistance() 
    {
        return Vector2.Distance(LastNode.transform.position, _player.transform.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(LastNode.transform.position, _player.transform.position);
    }
}
