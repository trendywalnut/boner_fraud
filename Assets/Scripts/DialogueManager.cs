using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    public GameObject[] dialogueBoxes;

    public int dialogueI;

    private void Start()
    {
        dialogueI = 0;
        dialogueBoxes[0].SetActive(true);

        for (int i = 1; i < dialogueBoxes.Length; i++)
        {
            dialogueBoxes[i].SetActive(false);
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicked");
            Debug.Log(dialogueI);
            dialogueBoxes[dialogueI].SetActive(false);
            dialogueBoxes[dialogueI + 1].SetActive(true);
            dialogueI++;
        }
    }
}
