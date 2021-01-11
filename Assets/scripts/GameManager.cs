using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //0 - crash, 1 - buzz buzz, 2 - carignition, 3 - sirens, 4 - textpop
    public AudioClip[] sfxClips;

    //0 - dialogue loop, 1 - ooberwave, 2 - cassette synthwave
    public AudioClip[] musicClips;

    private AudioSource aS;

    public float starRating = 5;

    public Animator blackFade;
    public Animator textFade;
    public GameObject blackFadeGO;
    public GameObject text;
    public GameObject restartButton;
    public GameObject quitButton;

    public GameObject spawner;
    public Spawner spawnerScript;

    public GameObject car;

    void Awake()
    {
        Time.timeScale = 1;
        if (FindObjectsOfType<GameManager>().Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

        aS = GetComponent<AudioSource>();

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {

            car = GameObject.FindGameObjectWithTag("Player");
            car.gameObject.GetComponent<BoxCollider2D>().enabled = true;

            spawner = GameObject.FindGameObjectWithTag("Spawner");
            spawnerScript = spawner.GetComponent<Spawner>();

            restartButton = GameObject.FindGameObjectWithTag("RestartButton");
            quitButton = GameObject.FindGameObjectWithTag("QuitButton");

            restartButton.GetComponent<Button>().enabled = false;
            restartButton.GetComponent<Image>().enabled = false;
            quitButton.GetComponent<Button>().enabled = false;
            quitButton.GetComponent<Image>().enabled = false;

            blackFadeGO = GameObject.FindGameObjectWithTag("game over");
            text = GameObject.FindGameObjectWithTag("game over 2");
            blackFade = blackFadeGO.GetComponent<Animator>();
            textFade = blackFadeGO.GetComponent<Animator>();
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (aS.clip != musicClips[2] || !aS.isPlaying)
            {
                aS.clip = musicClips[2];
                aS.Play();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (aS.clip != musicClips[0] || !aS.isPlaying)
            {
                aS.clip = musicClips[0];
                aS.Play();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (aS.clip != musicClips[1] && spawnerScript.gameStart || !aS.isPlaying && spawnerScript.gameStart)
            {
                aS.clip = musicClips[1];
                aS.Play();
                aS.loop = true;
            }
        }
    }

    public void PlaySoundEffect(int index)
    {
        aS.PlayOneShot(sfxClips[index]);
    }

    public void amDead()
    {
            StartCoroutine(endGame());
            blackFade.Play("fadeAnimation");
            textFade.Play("textFade");
            restartButton.GetComponent<Image>().enabled = true;
            restartButton.GetComponent<Button>().enabled = true;
            quitButton.GetComponent<Button>().enabled = true;
            quitButton.GetComponent<Image>().enabled = true;
    }

    public void RestartLevel()
    {
        Debug.Log("Restart!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        starRating = 5;
        aS.Stop();
        Invoke("ResetVars", .1f);
    }

    IEnumerator endGame()
    {
        yield return new WaitForSeconds(4);
        car.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void ResetVars()
    {
        spawnerScript.gameStart = false;
        car = GameObject.FindGameObjectWithTag("Player");
        restartButton = GameObject.FindGameObjectWithTag("RestartButton");
        quitButton = GameObject.FindGameObjectWithTag("QuitButton");
        blackFadeGO = GameObject.FindGameObjectWithTag("game over");
        text = GameObject.FindGameObjectWithTag("game over 2");
        blackFade = blackFadeGO.GetComponent<Animator>();
        textFade = blackFadeGO.GetComponent<Animator>();
        //restartButton.SetActive(false);
    }

}
