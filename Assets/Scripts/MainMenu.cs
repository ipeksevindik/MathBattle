using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject settings;
    public GameObject menu;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void QuitGame()
    {
        Debug.Log("Out of the game");
        Application.Quit();
    }

    public void ShowSettings()
    {
        menu.SetActive(false);
        settings.SetActive(true);
    }


    public void SettingsToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SetQuality(int qual)
    {
        QualitySettings.SetQualityLevel(qual);
    }

   

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayBattle()
    {
        SceneManager.LoadScene("Battle");
    }


    public void ReturnToGames()
    {
        SceneManager.LoadScene(1);
    }
}
