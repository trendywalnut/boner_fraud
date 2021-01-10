using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void Awake()
    {
        if (FindObjectsOfType<GameManager>().Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
        aS = GetComponent<AudioSource>();
        blackFadeGO = GameObject.FindGameObjectWithTag("game over");
        text = GameObject.FindGameObjectWithTag("game over 2");
        blackFade = blackFadeGO.GetComponent<Animator>();
        textFade = blackFadeGO.GetComponent<Animator>();
    }

    // Update is called once per frame
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

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            amDead();
            if (aS.clip != musicClips[1] || !aS.isPlaying)
            {
                aS.clip = musicClips[1];
                //aS.Play();
            }
        }
    }

    public void PlaySoundEffect(int index)
    {
        aS.PlayOneShot(sfxClips[index]);
    }

    public void amDead()
    {
        if (starRating == 0)
        {
            StartCoroutine(endGame());
            blackFade.Play("fadeAnimation");
            textFade.Play("textFade");
            endGame();
        }
    }

    IEnumerator endGame()
    {
        yield return new WaitForSeconds(4);
        Time.timeScale = 0;
    }
}
