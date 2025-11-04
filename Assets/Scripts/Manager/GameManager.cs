using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player player;
    public Enemy enemy;
    public BasePet pet;

    [SerializeField] private MapLooper mapLooper;
    [SerializeField] private CharacterSpawner characterSpawner;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private PetSpawner petSpawner;

    private SoundManager soundManager;

    private int currentScore = 0;
    private int bestScore = 0;

    private float time = 0;
    [SerializeField] private float levelSpeedUp = 6;

    public bool isPlay;
    [SerializeField] private bool isLevelUp;
    
    public float RemainingDistance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        soundManager = SoundManager.Instance;
        bestScore = PlayerPrefs.GetInt("BestScore", bestScore);
        player = characterSpawner.SpawnCharacter();
        enemy = enemySpawner.SpawnEnemy();
        pet = petSpawner.SpawnPet(player);

        GameStart();
    }

    private void Update()
    {
        if (!isPlay)
        {
            return;
        }

        RemainingDistance = player.transform.position.x - enemy.transform.position.x;

        time += Time.deltaTime;
        if (time > 30 && !isLevelUp)
        {
            MapSpeedUp();
            isLevelUp = true;
        }
    }

    public void GameStart()
    {
        soundManager.PlayBgm(EBgmName.InGame);
        currentScore = 0;
        isPlay = true;
        isLevelUp = false;
    }

    public void Crash()
    {
        enemy.Approach();
        if (RemainingDistance < 1)
        {
            pet.PetSkill();
        }
    }

    public void PlayerSpeedUp()
    {
        enemy.Retreat();
    }

    public void MapSpeedUp()
    {
        soundManager.PlayBgm(EBgmName.HurryUp);
        mapLooper.SetSpeed(levelSpeedUp);
    }

    public void AddScore(int value)
    {
        currentScore += value;
        InGameUIManager.Instance.UpdateScore(currentScore);
    }

    public void GameOver()
    {
        if (!isPlay)
            return;
        isPlay = false;
        soundManager.PlayBgm(EBgmName.GameOver);
        RemainingDistance = 0;
        mapLooper.SetSpeed(0);

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }

        InGameUIManager.Instance.SetGameOver(currentScore, bestScore);
    }

    public void TogglePause()
    {
        bool isPaused = Time.timeScale == 0f; 
        Time.timeScale = isPaused ? 1f : 0f; 
    }
}