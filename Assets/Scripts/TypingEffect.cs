using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingEffect : MonoBehaviour
{

    public float delay = 0.1f;

    [TextArea(15, 10)]
    public string fullText;
    private string currentText = "";

    private bool hasRun = false;
    public bool allTextShown = false;

    public GameObject strawberry;
    public TextMeshProUGUI textMesh;

    public AudioSource typeSource;
    public AudioClip typeSound;

    private void Start()
    {
        strawberry.SetActive(false);
        typeSource.volume = 0.7f;
    }

    private void Update()
    {
        if (gameObject.activeSelf == true && !hasRun)
        {
            StartCoroutine(ShowText());
            hasRun = true;
        }

        if (currentText.Length == fullText.Length - 1)
        {
            strawberry.SetActive(true);
            allTextShown = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            delay /= 4f;
        }

    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            if (i % 2 == 0)
            {
                typeSource.PlayOneShot(typeSound);
            }                
            currentText = fullText.Substring(0, i);
            textMesh.text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }


}
