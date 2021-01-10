using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButtonSave : MonoBehaviour
{
    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("RestartButton").Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
