using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] GameObject menuTitre;

    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public GameObject optionsWindow;

    Resolution[] resolutions;


    public void Start() //gere le menu principal
    {
        //cherche toutes les resolutions possible du pc
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray(); 

        resolutionDropdown.ClearOptions();  //clear les options du dropdown par défaut

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++) //merci tuto fr unity2d (:
        {
            string option = resolutions[i].width + " * " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height) //check la resoltion par defaut
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        Screen.fullScreen = true;
    }

    public void PlayButton() 
    {
        SceneManager.LoadScene("SpawnTest");
        Time.timeScale = 1f;
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void OptionsButton()
    {
        optionsWindow.SetActive(true);
    }

    public void QuitOptionsButton()
    {
        optionsWindow.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SetVolume(float volume) //gere le volume
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullScreen(bool isFullScreen)    //met en fullscreen
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex) //change la resolution
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
