using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignSpawner : MonoBehaviour
{

    private float smallSignTimer = 0;
    public float maxSmallSignTime = 8.1f;
    private float bigSignTimer = 0;
    public float maxBigSignTime = 14.3f;
    public float smallSignSpeed = 10;
    public float bigSignSpeed = 14;
    public static float signSpeed = 14;
    private bool rand;
    public GameObject smallSign1;
    public GameObject smallSign2;
    public GameObject bigSign;

    void Update()
    {

        if (smallSignTimer > maxSmallSignTime) {
            signSpeed = smallSignSpeed;
            rand = (Random.value >= 0.5);
            if (rand) {
                GameObject new_small_sign = Instantiate(smallSign1);
                new_small_sign.transform.position = new Vector3(10.0f, 3.2f, 10.11f);
            } else {
                GameObject new_small_sign = Instantiate(smallSign2);
                new_small_sign.transform.position = new Vector3(10.0f, 3.2f, 10.11f);
            }
            smallSignTimer = 0;
        }

        if (bigSignTimer > maxBigSignTime) {
            signSpeed = bigSignSpeed;
            GameObject new_big_sign = Instantiate(bigSign);
            new_big_sign.transform.position = new Vector3(10.0f, 0.1f, 0);
            bigSignTimer = 0;
        }

        smallSignTimer += Time.deltaTime;
        bigSignTimer += Time.deltaTime;
    }

}
