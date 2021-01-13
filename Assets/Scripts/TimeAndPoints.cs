using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeAndPoints : MonoBehaviour
{
    Text pointText;
    Text timeText;
    Text highScoreText;

    public int pointsGathered = 0;
    int highScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        pointText = GameObject.Find("TimeText").GetComponent<Text>();
        timeText = GameObject.Find("PointsText").GetComponent<Text>();
        highScoreText = GameObject.Find("HighScoreText").GetComponent<Text>();
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        TimerRunning();
        AmountOfPointsHad();
    }

    private void TimerRunning()
    {
        timeText.text = "Timer: " + Time.timeSinceLevelLoad.ToString("0.0");
    }
    
    private void AmountOfPointsHad()
    {
        pointText.text = "Points: " + pointsGathered.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();
    }
    public void SaveHighScore()
    {
        if(pointsGathered > highScore)
        {
            highScore = pointsGathered;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
}
