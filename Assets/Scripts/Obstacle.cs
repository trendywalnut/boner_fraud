using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameManager gameManager;

    public float myObstacleSpeed;
    public float lifespan = 10;

    private GameObject player;
    private CarController carController;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        carController = player.GetComponent<CarController>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.PlaySoundEffect(1);
        //Debug.Log("test");
        if (carController.starRating >= 2)
        {
            carController.starRating--;
            Debug.Log(carController.starRating);
        }
        else if (carController.starRating == 1)
        {
            //game over gottem
            //Debug.Log("end game");
        }
    }

}
