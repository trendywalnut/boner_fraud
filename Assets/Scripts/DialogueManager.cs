using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    public GameObject[] dialogueBoxes;

    public int dialogueI;
    private TypingEffect tEffect;

    public AudioSource dialogueSound;
    public AudioClip clickSound;

    public GameObject spawner, score;
    private Spawner spawnerScript;
    private ScoreManager scoreM;

    private void Start()
    {
        dialogueI = 0;
        dialogueBoxes[0].SetActive(true);

        score = GameObject.FindGameObjectWithTag("Score");
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        spawnerScript = spawner.GetComponent<Spawner>();
        scoreM = score.GetComponent<ScoreManager>();

        tEffect = dialogueBoxes[0].GetComponent<TypingEffect>();

        for (int i = 1; i < dialogueBoxes.Length; i++)
        {
            dialogueBoxes[i].SetActive(false);
        }
    }

    private void Update()
    {

        if(Input.GetMouseButtonDown(0) && tEffect.allTextShown == true)
        {
            if (dialogueI == dialogueBoxes.Length - 1)
            {
                dialogueBoxes[dialogueI].SetActive(false);
                dialogueI++;
            }
            else
            {
                dialogueSound.PlayOneShot(clickSound);
                dialogueBoxes[dialogueI].SetActive(false);
                dialogueBoxes[dialogueI + 1].SetActive(true);
                dialogueI++;
                tEffect = dialogueBoxes[dialogueI].GetComponent<TypingEffect>();
            }
        }

        if (dialogueI == dialogueBoxes.Length)
        {
            spawnerScript.gameStart = true;
            scoreM.gameStart = true;
        }
    }
}
