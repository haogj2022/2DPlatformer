using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueNPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public List<string> dialogueLines;
    private int currentLineIndex = 0;

    private float wordSpeed = 0.05f;
    public bool isDialogueActive = false;

    public void ZeroText()
    {
        dialogueText.text = "";
        currentLineIndex = 0;
        isDialogueActive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDialogueActive = true;
            dialoguePanel.SetActive(true);
            StartCoroutine(DisplayDialogue());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDialogueActive = false;
            dialoguePanel.SetActive(false);
            ZeroText();
        }
    }

    private IEnumerator DisplayDialogue()
    {
        while (isDialogueActive && currentLineIndex < dialogueLines.Count)
        {
            dialogueText.text = "";
            string line = dialogueLines[currentLineIndex];
            foreach (char letter in line.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(wordSpeed);
            }
            currentLineIndex++;
            yield return new WaitForSeconds(1f);
        }
        ZeroText();
        dialoguePanel.SetActive(false);
    }
}
