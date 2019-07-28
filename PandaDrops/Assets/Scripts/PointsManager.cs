using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public Text scoreText;
    [Range(0,100)]
    public int score;

    void Start()
    {
        score = 0;
    }
    
    void Update()
    {
        PlayerPrefs.SetInt("Score",score);
        if(PlayerPrefs.GetInt("Score")<=0)
        {
           PlayerPrefs.SetInt("Score",0); 
        }
        scoreText.text = ""+PlayerPrefs.GetInt("Score");
    }

    public void AddScore()
    {
        score++;
    }

    public void Restart()
    {
        score = 0;
        PlayerPrefs.DeleteKey("Score");
    }
}
