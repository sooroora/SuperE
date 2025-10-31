using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;
    [SerializeField] private MapLooper mapLooper;
    [SerializeField] private CharacterSpawner characterSpawner;

    public int currentScore = 0;
    public int bestScore = 0;

    private float time = 0;

    public bool isPlay;
    public bool isCrash;

    public void Crash()
    {
        isCrash = true;
        enemy.Move();
    }

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", bestScore);
        characterSpawner.SpawnCharacter();
    }

    private void Update()
    {
        if (!isPlay)
            return;
        SpeedUp();
    }

    public void GameStart()
    {
        currentScore = 0;
        isPlay = true;
    }

    public void SpeedUp()
    {
        time += Time.deltaTime;
        if (time > 30)
        {
            //mapLooper.
        }
    }

    public void AddScore(int value)
    {
        currentScore += value;
        InGameUIManager.Instance.UpdateScore(currentScore);
    }

    public void GameOver()
    {
        isPlay = false;

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }

        InGameUIManager.Instance.SetGameOver(currentScore, bestScore);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnLobby()
    {
        //lobby or title æ¿¿∏∑Œ
    }

    public void TogglePause()
    {
        bool isPaused = Time.timeScale == 0f; 
        Time.timeScale = isPaused ? 1f : 0f; 
    }
}