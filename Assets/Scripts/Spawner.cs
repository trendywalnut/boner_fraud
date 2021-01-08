using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public float carTimer = 0;
    public float maxCarTime = 30;
    public static float carSpeed = 4;
    public float obstacleTimer = 0;
    public float maxObstacleTime = 7;
    public static float obstacleSpeed = 8;
    public GameObject enemyCar;
    public GameObject obstacle;
    public float yPosition;
    public float[] positions = new float[]{1.5f, -0.5f, -2.5f};
    private int lastLane; //Remembers last lane so obstacles never overlap
    private int myLane;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(carTimer > maxCarTime){
            pickRandomLane();
            GameObject new_car = Instantiate(enemyCar);
            new_car.transform.position = transform.position;
            carTimer = 0;
        }

        if(obstacleTimer > maxObstacleTime){
            pickRandomLane();
            GameObject new_obstacle = Instantiate(obstacle);
            new_obstacle.transform.position = transform.position;
            obstacleTimer = 0;
        }

        carTimer += Time.deltaTime;
        obstacleTimer += Time.deltaTime;
    }

    void pickRandomLane(){
        myLane = Random.Range(0, 3);
        while(myLane == lastLane){
            myLane = Random.Range(0, 3);
        }
        yPosition = positions[myLane];
        lastLane = myLane;
        transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
    }

}