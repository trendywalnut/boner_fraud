using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RestartButtonSave : MonoBehaviour
{

    public GameManager gMScript;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gMScript = FindObjectOfType<GameManager>();
    }

    public void RestartLevel()
    {
        gMScript.RestartLevel();
        player.GetComponent<BoxCollider2D>().enabled = true;
    }
}
