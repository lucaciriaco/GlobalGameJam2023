using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Transform _lastNode;
    public bool BigNode = false;
    public List<PickUp> PickUps;

    [SerializeField] private LineRenderer _line;

    public void Init(Transform lastNode)
    {
        _lastNode = lastNode;
        if (_lastNode != null)
        {
            _line.SetPosition(0, _lastNode.transform.position);
            _line.SetPosition(1, this.transform.position);
        }
    }
    public void Init(Transform lastNode, bool bigNode)
    {
        Init(lastNode);
        BigNode = bigNode;
    }
}
