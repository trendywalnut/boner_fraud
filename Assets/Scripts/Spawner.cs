using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    private float carTimer = 0;
    public float maxCarTime = 30;
    public static float carSpeed = 6f;
    private float obstacleTimer = 0;
    public float maxObstacleTime = 7;
    public static float obstacleSpeed = 11.3f;
    public static float warningDelay = 1.0f;
    private float warningTimer = 0.0f;
    public GameObject enemyCar;
    public GameObject obstacle;
    public GameObject warning;
    private float yPosition;
    public float[] carPositions = new float[3];
    public float[] obsPositions =  new float[3];
    private int lastLane; //Remembers last lane so obstacles never overlap
    private int myLane;
    private int obstacleLane;
    private bool isWarning = false;

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

        if(obstacleTimer > maxObstacleTime && !isWarning){
            pickRandomLane();
            obstacleLane = myLane;
            GameObject new_warning = Instantiate(warning);
            new_warning.transform.position = transform.position;
            isWarning = true;
        }

        if(warningTimer > warningDelay){
            yPosition = obsPositions[obstacleLane];
            transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
            GameObject new_obstacle = Instantiate(obstacle);
            new_obstacle.transform.position = transform.position;
            obstacleTimer = 0;
            isWarning = false;
            warningTimer = 0;
        }

        if(isWarning){
            warningTimer += Time.deltaTime;
        }

        carTimer += Time.deltaTime;
        obstacleTimer += Time.deltaTime;
    }

    void pickRandomLane(){
        myLane = Random.Range(0, 3);
        while(myLane == lastLane){
            myLane = Random.Range(0, 3);
        }
        yPosition = carPositions[myLane];
        lastLane = myLane;
        transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
    }

}