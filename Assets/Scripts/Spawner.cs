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
    private float copTimer = 0;
    public float maxCopTime = 7.5f;
    public static float copSpeed = 24;
    public static float copWarningDelay = 1.0f;
    private float copWarningTimer = 0.0f;
    public GameObject enemyCar;
    public GameObject obstacle;
    public GameObject copCar;
    public GameObject warning;
    private float yPosition;
    public float[] carPositions = new float[3];
    public float[] obsPositions =  new float[3];
    public float[] copPositions = new float[2];
    private int lastLane; //Remembers last lane so obstacles never overlap
    private int myLane;
    private int copLane;
    private int obstacleLane;
    private bool isWarning = false;
    private bool isCopWarning = false;
    public bool gameStart = false;

    // Start is called before the first frame update
    void Start()
    {
        gameStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            if (carTimer > maxCarTime)
            {
                pickRandomLane();
                GameObject new_car = Instantiate(enemyCar);
                new_car.transform.position = transform.position;
                carTimer = 0;
            }

            if (obstacleTimer > maxObstacleTime && !isWarning)
            {
                pickRandomLane();
                obstacleLane = myLane;
                GameObject new_warning = Instantiate(warning);
                new_warning.transform.position = new Vector3(4f, transform.position.y, transform.position.z);
                isWarning = true;
            }

            if (warningTimer > warningDelay)
            {
                yPosition = obsPositions[obstacleLane];
                transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
                GameObject new_obstacle = Instantiate(obstacle);
                new_obstacle.transform.position = transform.position;
                obstacleTimer = 0;
                isWarning = false;
                warningTimer = 0;
            }

            if (copTimer > maxCopTime && !isCopWarning)
            {
                myLane = Random.Range(0, 2);
                yPosition = copPositions[myLane];
                copLane = myLane;
                transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
                GameObject new_cop_warning = Instantiate(warning);
                new_cop_warning.transform.position = new Vector3(-10f, transform.position.y, transform.position.z);
                isCopWarning = true;
            }

            if (copWarningTimer > copWarningDelay)
            {
                yPosition = copPositions[copLane];
                transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
                GameObject new_cop = Instantiate(copCar);
                new_cop.transform.position = new Vector3(-13f, transform.position.y + 0.3f, transform.position.z);
                copTimer = 0;
                isCopWarning = false;
                copWarningTimer = 0;
            }

            if (isWarning)
            {
                warningTimer += Time.deltaTime;
            }

            if(isCopWarning){
                copWarningTimer += Time.deltaTime;
            }

            carTimer += Time.deltaTime;
            obstacleTimer += Time.deltaTime;
            copTimer += Time.deltaTime;
        }
        
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