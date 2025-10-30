using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private UIBase uiBase;
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;
    [SerializeField] private MapLooper mapLooper;

    public float currentScore = 0;
    public float bestScore = 0;

    public bool isPlay;
    public bool isCrash;

    public void Crash()
    {
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
        bestScore = PlayerPrefs.GetFloat("BestScore", bestScore);
    }

    private void Update()
    {
        if(!isPlay)
            return;

        AddScore(Time.deltaTime);
    }

    public void GameStart()
    {
        currentScore = 0;
        isPlay = true;
        //mapLooper
    }

    public void SpeedUp()
    {
        //mapLooper.
    }

    public void AddScore(float value)
    {
        currentScore += value;
    }

    public void GameOver()
    {
        isPlay = false;

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetFloat("BestScore", bestScore);
        }

        //UI
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnLobby()
    {
        //lobby or title æ¿¿∏∑Œ
    }
}
