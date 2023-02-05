using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private NodeManager NodeManager;
    public GameObject partHolder;
    public GameManager gameManager;

    private float _delay = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this._delay -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Traps" && this._delay <= 0) 
        {
            this._delay = 1f/60f;
            NodeManager.ReturnLastNode();




        }
    }
   
}
