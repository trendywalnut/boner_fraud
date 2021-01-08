using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    
    private float newCarSpeed;
    public Spawner mySpawner;
    
    // Start is called before the first frame update
    void Start()
    {
        mySpawner = GameObject.FindGameObjectsWithTag("Spawner");
        newCarSpeed = mySpawner.carSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.left * newCarSpeed * Time.deltaTime);
    }
}
