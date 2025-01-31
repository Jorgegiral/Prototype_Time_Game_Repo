using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    private TextMeshProUGUI dialogueText;
    private float typingTime = 0.05f;

    public GameObject dialogueActive;
    public GameObject dialogueNext;
    public GameObject dialogueBack;
    public GameObject dialoguePanel;
    private string fullText;

    void Start()
    {
        dialogueText = GetComponent<TextMeshProUGUI>();
        if (dialogueText != null)
        {
            fullText = dialogueText.text;
            dialogueText.text = "";
            StartCoroutine(TypeText());
        }
    }

    private IEnumerator TypeText()
    {
        foreach (char ch in fullText)
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
    }

    void Update()
    {
        if (dialogueActive.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1))
            {
                if (dialogueNext == null)
                {
                    dialogueActive.SetActive(false);
                    dialogueBack.SetActive(true);
                    dialoguePanel.SetActive(false);
                }
                else
                {
                    dialogueActive.SetActive(false);
                    dialogueNext.SetActive(true);
                }
            }
        }
    }
}
