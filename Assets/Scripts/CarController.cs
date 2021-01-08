using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    private Transform tf;

    public float moveSpeed;
    public bool useFourDirections;

    private void Start()
    {
        tf = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            tf.Translate(Vector3.up * moveSpeed);
        } 
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            tf.Translate(Vector3.up * -moveSpeed);
        }

        if(useFourDirections)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                tf.Translate(Vector3.left * moveSpeed);
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                tf.Translate(Vector3.right * moveSpeed);
            }
        }
    }

}
