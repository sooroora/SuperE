using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float currentScore = 0;
    public float bestScore = 0;

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

    private void Update()
    {
        currentScore += Time.deltaTime;
    }

    public void GameOver()
    {
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
        }
        currentScore = 0;
    }

    public void SpeedUp()
    {

    }


}
