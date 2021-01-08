using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    private Transform tf;
    private Rigidbody2D rb;

    public float moveSpeed;
    public bool useFourDirections;

    private void Start()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, 1) * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, 1) * -moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

}
