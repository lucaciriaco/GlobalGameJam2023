using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public GameObject _lastNode;

    [SerializeField] private LineRenderer _line;

    void Start()
    {
        if(_lastNode != null)
        {
            _line.SetPosition(0, _lastNode.transform.position);
            _line.SetPosition(1, this.transform.position);
        }
    }
}
