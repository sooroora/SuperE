using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameOverUI gameOverUI;
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;
    [SerializeField] private MapLooper mapLooper;
    [SerializeField] private ItemSpawnManager spawnManager;

    public int currentScore = 0;
    public int bestScore = 0;

    public bool isPlay;
    public bool isCrash;

    public void Crash()
    {
        isCrash = true;
        enemy.Move();
    }


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", bestScore);
        //spawnManager.PlaceItems();
    }

    private void Update()
    {
        if (!isPlay)
            return;
    }

    public void GameStart()
    {
        currentScore = 0;
        isPlay = true;
        spawnManager.PlaceItems();
    }

    public void SpeedUp()
    {
        //mapLooper.
    }

    public void AddScore(int value)
    {
        currentScore += value;
        //UI
    }

    public void GameOver()
    {
        isPlay = false;

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }

        gameOverUI.Show(currentScore, bestScore);
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