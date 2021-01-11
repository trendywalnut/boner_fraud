using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RestartButtonSave : MonoBehaviour
{

    public GameManager gMScript;

    private void Awake()
    {
        gMScript = FindObjectOfType<GameManager>();
    }

    public void RestartLevel()
    {
        gMScript.RestartLevel();    
    }
}
