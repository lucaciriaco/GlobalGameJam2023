using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Action<PickUp> OnPlayerPickUp;

    public void AddCuantityOfNodes()
    {
        gameObject.SetActive(false);
    }

    public void SubstractCuantityOfNodes()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            OnPlayerPickUp?.Invoke(this);
        }
    }
}
