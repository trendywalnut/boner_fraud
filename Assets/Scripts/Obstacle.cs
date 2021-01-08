﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    
    public float myObstacleSpeed;
    public float lifespan = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        myObstacleSpeed = Spawner.obstacleSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.left * myObstacleSpeed * Time.deltaTime);
        lifespan -= Time.deltaTime;

        if(lifespan <= 0){
            Destroy(gameObject);
        }
    }

}