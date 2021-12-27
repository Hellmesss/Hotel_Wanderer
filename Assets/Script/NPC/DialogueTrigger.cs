using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject NPCdialogue;


    public NPCdialogue dialogue;

    public bool isInRange;


    private void Start() //script non termine, suppose activer / desactiver la fenetre de dialogue si on est dans la range su PNJ
    {
        NPCdialogue.SetActive(false);
    }

    void Update()
    {

        if (isInRange && Input.GetKeyDown(KeyCode.F))
        {

            NPCdialogue.SetActive(true);
            TriggerDialogue();

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            NPCdialogue.SetActive(false);

        }
    }

    void TriggerDialogue()
    {
        Dialoguemanager.instance.StartDialogue(dialogue);
    }
}