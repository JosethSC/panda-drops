using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject hud;
    private Health player;
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Level")
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        }
        Time.timeScale = 1;
        menuCanvas.SetActive(false);
        hud.SetActive(true);
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Level")
        {
            if(player!=null)
            {
                if(player.health<=0)
                {
                    YouLose();
                }
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        menuCanvas.SetActive(true);
        hud.SetActive(false);  
    }
    public void ReanudeGame()
    {
        Time.timeScale = 1;
        menuCanvas.SetActive(false);
        hud.SetActive(true);       
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
