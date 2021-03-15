using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreKeeper : MonoBehaviour
{
    public Text score;
    int currentScore = 0000;
    public HighScore HighScore;
    public int alienCounter = 16;
    
    void Start()
    {
        score.text = currentScore.ToString("0000");
    }

    public void displayScore()
    {
        score.text = currentScore.ToString("0000");
        checkHighScore();

    }

    void checkHighScore()
    {
        HighScore.checkScore(currentScore);
    }

    public void mysteryAlienIncrease()
    {
        currentScore += 40;
        displayScore();
    }

    public void alien3Increase()
    {
        currentScore += 30;
        displayScore();
    }

    public void alien2Increase()
    {
        currentScore += 20;
        displayScore();
    }

    public void alien1Increase()
    {
        currentScore += 10;
        displayScore();
    }

    public void decreaseAlienCount()
    {
        alienCounter--;
        Debug.Log(alienCounter);
    }

    public int getAlienCount()
    {
        return alienCounter;
    }
}
