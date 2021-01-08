using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public float carTimer = 0;
    public float maxCarTime = 30;
    public float carSpeed = 2;
    public float obstacleTimer = 0;
    public float maxObstacleTime = 100;
    public GameObject enemyCar;
    public GameObject obstacle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(carTimer > maxCarTime){
            GameObject new_car = Instantiate(enemyCar);
            new_car.transform.position = transform.position;
            carTimer = 0;
        }

        carTimer += Time.deltaTime;
        obstacleTimer += Time.deltaTime;
    }
}