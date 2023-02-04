using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigNode : MonoBehaviour
{
    [SerializeField] private LineRenderer _line;

    public Action OnPlayerEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OnPlayerEnter?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
