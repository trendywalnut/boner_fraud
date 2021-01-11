using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueSceneManager : MonoBehaviour
{

    public GameObject secondManager;
    public DialogueManager dM;
    public DialogueManager dM2;

    public Image bg2;
    public Animator bgAnim;

    public bool firstScene = true;

    public GameObject continueButton;

    private void Start()
    {
        secondManager.SetActive(false);

        continueButton = GameObject.FindGameObjectWithTag("ContinueButton");
        continueButton.GetComponent<Button>().enabled = false;
        continueButton.GetComponent<Image>().enabled = false;
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

        if (dM2.dialogueI >= 10)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            continueButton.GetComponent<Button>().enabled = true;
            continueButton.GetComponent<Image>().enabled = true;
        }

    }

}
