using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InGameUI : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI scoreText;          
    public Button pauseButton;
    public TextMeshProUGUI distanceText;

    private void Start()
    {
        
        if (pauseButton != null)
            pauseButton.onClick.AddListener(OnPauseButtonClicked);

        
        UpdateScore(0);
        UpdateDistance(0);
    }
    private void Update()
    {
        // 매 프레임 거리 갱신
        if (GameManager.Instance != null)
        {
            float distance = Mathf.Max(0, GameManager.Instance.RemainingDistance);
            UpdateDistance(distance);
        }
    }


    public void UpdateScore(int score)
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
    private void UpdateDistance(float distance)
    {
        if (distanceText != null)
            distanceText.text = "Distance: " + distance.ToString("F1");

    }


    private void OnPauseButtonClicked()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.TogglePause();
        }
    }
}
