using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject proyectile;
    public float timeBetweenInstances;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("launchProyectile",1f, timeBetweenInstances);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void launchProyectile()
    {
        Instantiate(proyectile,spawnPoint);
    }
}
