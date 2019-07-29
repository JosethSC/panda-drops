using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ReanudeGame()
    {
        Time.timeScale = 1;      
    }

    public void YouLose()
    {
        PlayerPrefs.DeleteKey("Score");
        SceneManager.LoadScene("Lose");
    }
    public void Restart()
    {
        PlayerPrefs.DeleteKey("Score");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        PlayerPrefs.DeleteKey("Score");
        SceneManager.LoadScene("Menu");
    }
    public void Play()
    {
        SceneManager.LoadScene("Level");
    }
    public void Exit()
    {
        PlayerPrefs.DeleteKey("Score");
        Application.Quit();
    }
}
