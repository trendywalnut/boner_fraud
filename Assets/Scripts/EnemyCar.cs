using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    
    public float myCarSpeed;
    public float lifespan = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        myCarSpeed = Spawner.carSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.left * myCarSpeed * Time.deltaTime);
        lifespan -= Time.deltaTime;

        if(lifespan <= 0){
            Destroy(gameObject);
        }
    }

}
