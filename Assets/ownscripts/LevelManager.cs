using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public static LevelManager Instance;


    public bool paused;
    public GameObject pauseMenu;
    public GameObject winWindow;

    private void Start()
    {
        pauseMenu.SetActive(false);
        winWindow.SetActive(false);

    }

    public void TogglePauseMenu()
    {

        pauseMenu.SetActive(!pauseMenu.activeSelf);

    }
    public void ToMenu()

    {
        SceneManager.LoadScene("Menu");
    }

    public void ToggleWinWindow()
    {
        winWindow.SetActive(!winWindow.activeSelf);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void TogglePause()
    {
        paused = !paused;

        if (paused)
        {
            Time.timeScale = 0;
        }
        else if (!paused)
        {
            Time.timeScale = 1;
        }
    }
}   
    

