using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    public GameManager gameManager;

    public float myCarSpeed;
    public float lifespan = 10;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
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
