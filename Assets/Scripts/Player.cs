using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject partHolder;
    public GameManager gameManager;

    private bool hasPart;
    private GameObject lastPart;
    private GameObject partGrabed;
    // Start is called before the first frame update
    void Start()
    {
        hasPart = false;
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if ((collision.gameObject.tag == "Part") && (hasPart == false))
        {
            hasPart = true;
            lastPart = collision.gameObject;
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Ship")
        {
            if (hasPart == true)
            {
                gameManager.partsCollected++;
                Destroy(lastPart);
                hasPart = false;
                Debug.Log("Lo deja en la nave");
            }
        }
        if (collision.gameObject.tag == "Traps" || collision.gameObject.tag == "Proyectile")
        {
            if(lastPart != null)
            {
                lastPart.gameObject.SetActive(true);
            }
            hasPart = false;
            gameManager.Restart();
        }
    }
}
