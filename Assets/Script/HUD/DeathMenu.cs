using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{

    [SerializeField] GameObject deathMenu;

    public void QuitButton()
    {
        Application.Quit();
    }

    public void LoadMenu() //button qui nous envoie sur le menu principal
    {
        SceneManager.LoadScene("MenuPrincipal");
        Time.timeScale = 1f;
    }

    public void RestartButton() //button qui nous relancer de quitter le jeu
    {
        SceneManager.LoadScene("SpawnTest");
        RoomSpawner.GrosuSpawned = false;
        Time.timeScale = 1f;
    }
}
