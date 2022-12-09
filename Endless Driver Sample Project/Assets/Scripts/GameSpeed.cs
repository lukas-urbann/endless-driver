using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeed : MonoBehaviour
{
    public Button restartButton;
    public static GameSpeed Instance;
    public Score score;
    private float gameSpeed = 2;
    
    public bool gameOver = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void Update()
    {
        CalculateGameSpeed();
    }

    private void CalculateGameSpeed()
    {
        if (!gameOver)
            gameSpeed = 2 + (score.GetScore() / 250);
        else
            gameSpeed = 0;
    }

    public float GetGameSpeed()
    {
        return gameSpeed;
    }

    public void GameOver()
    {
        gameOver = true;
        restartButton.gameObject.SetActive(true);
    }
}
