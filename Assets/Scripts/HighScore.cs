using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highScore;
    int currentScore = 0000;

    void Start()
    {
        highScore.text = currentScore.ToString("0000");
    }

    public void checkScore(int passedInScore)
    {
        if (currentScore < passedInScore)
        {
            currentScore = passedInScore;
            showHighScore();
        }
        else
        {
            showHighScore();
        }
    }

    void showHighScore()
    {
        highScore.text = currentScore.ToString("0000");
    }
}