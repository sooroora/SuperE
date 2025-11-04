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
        
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);
    }


    public void Show(int score, int bestScore)
    {
        gameObject.SetActive(true);

        scoreText.text     = score.ToString();
        bestScoreText.text = bestScore.ToString();
    }

    private void OnClickRestart()
    {
        SceneTransferManager.LoadScene(ESceneName.GameScene);
    }

    private void OnClickMain()
    {
        SceneTransferManager.ImmediagetLoadScene(ESceneName.TitleScene);
    }
    public void ShowGameOver()
    {
        // ���ӿ��� �� ȣ��
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(true);
    }
}
