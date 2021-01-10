using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    private Transform tf;
    private Rigidbody2D rb;

    public float maxSpeed = 5;
    public float moveSpeed;

    

    public bool classicControl;

    private void Start()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (rb.velocity.y <= maxSpeed && !classicControl)
            {
                rb.AddForce(Vector2.up * moveSpeed);
            }

            if (classicControl)
            {
                rb.velocity = new Vector2(rb.velocity.x, 1) * moveSpeed;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (rb.velocity.y * -1 <= maxSpeed && !classicControl)
            {
                rb.AddForce(Vector2.up * -moveSpeed);
            }

            if (classicControl)
            {
                rb.velocity = new Vector2(rb.velocity.x, 1) * -moveSpeed;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

}
