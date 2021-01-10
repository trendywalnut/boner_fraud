using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueSceneManager : MonoBehaviour
{

    public GameObject secondManager;
    public DialogueManager dM;

    public Image bg2;
    public Animator bgAnim;

    public bool firstScene = true;

    private void Start()
    {
        secondManager.SetActive(false);
    }

    private void Update()
    {
        if (!firstScene)
        {
            bgAnim.Play("FadeIn");
            secondManager.SetActive(true);
        }

        if (dM.dialogueI >= 4)
        {
            firstScene = false;
        }

        if (dM.dialogueI >= 14)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

}
