using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIManager : MonoBehaviour
{
    public static InGameUIManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        
    }
    GameOverUI gameOverUI;
    InGameUI inGameUI;
    public void SetGameOver(int score, int bestScore)
    {
        gameOverUI.Show(score, bestScore);
    }
    public void UpdateScore(int score)
    {
        inGameUI.UpdateScore(score);
    }
}
