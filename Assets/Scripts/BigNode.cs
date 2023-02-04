using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigNode : MonoBehaviour
{
    [SerializeField] private LineRenderer _line;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            this.gameObject.transform = collision.GetComponent<NodeManager>()._lastNode;
        }
    }
}
