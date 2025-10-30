using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [Header("UI References")]
    public Text scoreText;          
    public Button pauseButton;      

    private void Start()
    {
        
        if (pauseButton != null)
            pauseButton.onClick.AddListener(OnPauseButtonClicked);

        
        UpdateScore(0);
    }

    
    public void UpdateScore(int score)
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    
    private void OnPauseButtonClicked()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.TogglePause();
        }
    }
}
