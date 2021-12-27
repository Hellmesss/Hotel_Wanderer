using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingGame : MonoBehaviour
{

    public bool isLoadable = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (this.CompareTag("Nounours"))  //check le tag de l'objet avec lequel on rentre en collision
            {
                isLoadable = true;
                SceneManager.LoadScene("EndingScene");
            }
        }
    }
}
