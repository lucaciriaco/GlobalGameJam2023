using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    public List<GameObject> nodes;
    public int _cuantityOfNodes;
    public Transform _lastNode;

    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _node;
    [SerializeField] private GameObject _level;
    [SerializeField] private LineRenderer _line;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float _distance;

    private List<RaycastHit2D> ray = new List<RaycastHit2D>();
    
    void Update()
    {
        var result = Physics2D.Linecast(_player.transform.position, _lastNode.transform.position, ground);
        if (result.collider == null)
        {
            return;
        }
        if(result.collider.GetComponent<Node>() != null)
        {
            DrawLine();
            if (Input.GetKeyDown(KeyCode.Joystick1Button1) == true && _cuantityOfNodes >= 0)
            {
                var instance = Instantiate(_node, _player.position, Quaternion.identity).transform;
                instance.GetComponent<Node>().Init(_lastNode);
                _lastNode = instance;
                _cuantityOfNodes--;
            }
        }
        //ReturnLastNode();
    }

    private void ReturnLastNode()
    {
        if(Input.GetKeyDown(KeyCode.Joystick1Button0) == true)
        {
            _player = _lastNode;
        }
    }

    private void DrawLine()
    {
        _line.SetPosition(0, _player.transform.position);
        _line.SetPosition(1, _lastNode.transform.position);
    }

    private float GetDistance() 
    {
        return Vector2.Distance(_lastNode.transform.position, _player.transform.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(_lastNode.transform.position, _player.transform.position);
    }
}
