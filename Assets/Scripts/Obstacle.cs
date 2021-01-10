using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameManager gameManager;

    public float myObstacleSpeed;
    public float lifespan = 10;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
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
        gameManager.PlaySoundEffect(0);
        //Debug.Log("test");
        if (gameManager.starRating != 0)
        {
            gameManager.starRating--;
            Debug.Log(gameManager.starRating);
        }
        else
        {
            gameManager.PlaySoundEffect(3);
        }
    }

}
