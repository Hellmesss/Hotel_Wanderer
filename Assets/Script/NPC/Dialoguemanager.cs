using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialoguemanager : MonoBehaviour
{


    public Text nameText;
    public Text dialogueText;

    private Queue<string> sentences;

    public static Dialoguemanager instance;

    private void Awake() //octroie la parole au PNJ ^^
    {
        if (instance != null)
        {
            return;
        }
        instance = this;

        sentences = new Queue<string>();
    }

    public void StartDialogue(NPCdialogue dialogue)
    {
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = " ";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }
}