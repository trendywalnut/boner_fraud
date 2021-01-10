using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningSign : MonoBehaviour
{
    
    public float blinkRate = 0.2f;
    public float blinkTimer = 0.0f;
    public float lifespan = Spawner.warningDelay;
    public bool isVisible;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(4f, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (blinkTimer > blinkRate){
            gameObject.GetComponent<SpriteRenderer>().enabled = isVisible;
            isVisible = !isVisible;
            blinkTimer = 0;
        }
        
        if (lifespan < 0.0f) {
            Destroy(gameObject);
        }
        
        lifespan -= Time.deltaTime;
        blinkTimer += Time.deltaTime;
    }
}
