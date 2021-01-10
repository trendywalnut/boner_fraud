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

    private void Start()
    {
        dialogueI = 0;
        dialogueBoxes[0].SetActive(true);

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
            dialogueSound.PlayOneShot(clickSound);
            dialogueBoxes[dialogueI].SetActive(false);
            dialogueBoxes[dialogueI + 1].SetActive(true);
            dialogueI++;
            tEffect = dialogueBoxes[dialogueI].GetComponent<TypingEffect>();
        }
    }
}
