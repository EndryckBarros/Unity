﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool isGameRunning;
    private int score;
    private int currentLevelIndex;

    public ObstacleGenerator generator;
    public GameConfigurator config;
    public TextMeshProUGUI scoreLabel;
    public GameUI gameStartUI;
    public GameUI gameOverUI;
    public PlayerController player;
    public LevelConfigurator[] levels;


    // Start is called before the first frame update
    void Start()
    {
        isGameRunning = false;

        
        gameStartUI.Show();
        config.speed = 0f;
    }

    private void Update()
    {
        scoreLabel.text = score.ToString("00000000.##");

        if (!isGameRunning) return;
        score++;
        CheckLevelUpdate();
    }

    private void CheckLevelUpdate()
    {
        if (currentLevelIndex >= levels.Length - 1) return;
        if (score < levels[currentLevelIndex + 1].minScore) return;
        currentLevelIndex++;

        SetCurrentLevelConfiguration();
    }

    private void SetCurrentLevelConfiguration()
    {
        LevelConfigurator level = levels[currentLevelIndex];
        config.speed = level.speed;
        config.minRangeObstacleGenerator = level.minRangeObstacleGenerator;
        config.maxRangeObstacleGenerator = level.maxRangeObstacleGenerator;
    }

    public void GameStart()
    {
        currentLevelIndex = 0;
        SetCurrentLevelConfiguration();

        isGameRunning = true;
        
        generator.GenerateObstacles();
        score = 0;
        gameStartUI.Hide();
        player.SetActive();
    }
    
    public void GameOver()
    {
        isGameRunning = false;

        config.speed = 0f;
        generator.StopGenerator();
        gameOverUI.Show();
    }

    public void RestartGame()
    {
        gameOverUI.Hide();
        generator.ResetGenerator();
        GameStart();
    }
}
