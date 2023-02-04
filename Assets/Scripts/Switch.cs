using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject[] thingToActivate;

    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = true;
        for(int i = 0;i<thingToActivate.Length;i++)
        {
            thingToActivate[i].SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i < thingToActivate.Length; i++)
            {
                thingToActivate[i].SetActive(true);
            }
            sprite.enabled = false;
        }
    }
}
