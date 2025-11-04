using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 


public class GameOverUI : MonoBehaviour
{
    [Header("UI Texts")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI gameOverText;

    [Header("Buttons")]
    public Button restartButton;
    public Button mainButton;

    private void Start()
    {
        
        restartButton.onClick.AddListener(OnClickRestart);
        mainButton.onClick.AddListener(OnClickMain);

        
        gameObject.SetActive(false);
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);
    }


    public void Show(int score, int bestScore)
    {
        gameObject.SetActive(true);

        scoreText.text = $"Score: {score}";
        bestScoreText.text = $"Best: {bestScore}";
    }

    private void OnClickRestart()
    {
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }

    private void OnClickMain()
    {
        
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
    public void ShowGameOver()
    {
        // 게임오버 시 호출
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(true);
    }
}
