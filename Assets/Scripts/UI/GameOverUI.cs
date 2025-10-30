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

    [Header("Buttons")]
    public Button restartButton;
    public Button mainButton;

    private void Start()
    {
        
        restartButton.onClick.AddListener(OnClickRestart);
        mainButton.onClick.AddListener(OnClickMain);

        
        gameObject.SetActive(false);
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
}
