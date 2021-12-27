using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{

    void Update() //permet de jouer l'animation de la ending scene
    {
        StartCoroutine(ChangeScene());

    }
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MenuPrincipal");
    }
}