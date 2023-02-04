using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _lastNode;
    [SerializeField] private GameObject _node;
    [SerializeField] private LineRenderer _line;
    private bool isBlocked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Linecast(_player.transform.position, _lastNode.transform.position) == false)
        {
            _line.SetPosition(0, _lastNode.transform.position);
            _line.SetPosition(1, this.transform.position);
            if (Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                Instantiate(_node, _player.transform);
                _node.GetComponent<Node>()._lastNode = _node;
            }
        }
    }
}
