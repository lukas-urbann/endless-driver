using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private float score = 0;
    public TMP_Text scoreText;
    
    private void Update()
    {
        if(!GameSpeed.Instance.gameOver)
            score += Time.deltaTime * 50;
        
        DisplayScore();
    }

    private void DisplayScore()
    {
        scoreText.text = score.ToString("F0");
    }

    public float GetScore()
    {
        return score;
    }
}
