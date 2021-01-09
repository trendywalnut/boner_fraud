using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    
    public float mySignSpeed;
    public float lifespan = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        mySignSpeed = SignSpawner.signSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.left * mySignSpeed * Time.deltaTime);
        lifespan -= Time.deltaTime;

        if(lifespan <= 0){
            Destroy(gameObject);
        }
    }
}
