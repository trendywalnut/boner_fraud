using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    public GameManager gameManager;

    public float myCarSpeed;
    public float lifespan = 10;

    private GameObject player;
    private CarController carController;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        carController = player.GetComponent<CarController>(); 
        myCarSpeed = Spawner.carSpeed;
    }

    void Update()
    {
        this.transform.Translate(Vector3.left * myCarSpeed * Time.deltaTime);
        lifespan -= Time.deltaTime;

        if(lifespan <= 0){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.PlaySoundEffect(0);

        //Debug.Log("test");
        if (carController.starRating >= 2)
        {
            carController.starRating--;
            Debug.Log(carController.starRating);
        }
        else if (carController.starRating == 1)
        {
            //game over gottem
            Debug.Log("end game");
        }
    }

}
