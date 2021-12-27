using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;

    [SerializeField] GameObject pauseMenu;

    void Update() //met en pause le menu
    {

        if (Input.GetKeyDown(KeyCode.P)) //activer le menu lorsqu'on joue
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void ResumeGame() //button pour reprendre la partie en cours
    {
        pauseMenu.SetActive(false);
        isGamePaused = false;
        Time.timeScale = 1f;
    }
    private void PauseGame() //fonction qui active notre menu et arrete le temps
    {
        pauseMenu.SetActive(true);
        isGamePaused = true;
        Time.timeScale = 0f;
    }
    public void LoadMenu() //button qui nous envoie sur le menu principal
    {
        SceneManager.LoadScene("MenuPrincipal");
        isGamePaused = false;
        Time.timeScale = 1f;
    }
    public void RestartButton() //button qui nous relancer de quitter le jeu
    {
        SceneManager.LoadScene("SpawnTest");
        RoomSpawner.GrosuSpawned = false;
        isGamePaused = false;
        Time.timeScale = 1f;
    }
}

