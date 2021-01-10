using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public GameObject[] starsArray;
    public GameObject player;
    public GameManager gameManager;
    public TextMeshProUGUI fareText;

    public float stars;
    private float fare = 0.00f;
    private float timer;

    public bool gameStart = false;

    private void Start()
    {
        gameStart = false;

        for (int i = 0; i < starsArray.Length; i++)
        {
            starsArray[i].SetActive(true);
        }

        fare = 0;
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = FindObjectOfType<GameManager>();
        stars = gameManager.starRating;
    }

    private void Update()
    {
        stars = gameManager.starRating;

        if (gameStart)
        {
            timer += Time.deltaTime;
            fare = timer / 4;
        }        

        fareText.text = "Tip: $" + fare.ToString("F2");

        switch (stars)
        {
            case 4:
                starsArray[3].SetActive(false);
                break;
            case 3:
                starsArray[2].SetActive(false);
                break;
            case 2:
                starsArray[1].SetActive(false);
                break;
            case 1:
                starsArray[0].SetActive(false);
                break;
            default:
                break;

        }
    }

}
