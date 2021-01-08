using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScroll : MonoBehaviour
{

    Material material;
    Vector2 offset;

    public int xVel;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    void Start()
    {
        offset = new Vector2(xVel, 0);
    }

    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
        
    }
}
