using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigNode : MonoBehaviour
{
    [SerializeField] private LineRenderer _line;
    [SerializeField] GameObject _bigNodeLit;
    [SerializeField] GameObject _bigNodeUnLit;

    public Action OnPlayerEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OnPlayerEnter?.Invoke();
            GetComponent<Collider2D>().enabled = false;
            _bigNodeLit.SetActive(true);
            _bigNodeUnLit.SetActive(false);
        }
    }
}
