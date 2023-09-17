using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Score { get; private set; }
    private readonly int _startingLives = 3;
    public int Lives { get; private set; }
    private readonly float _levelTimer = 60f;
    public float RemainingLevelTime { get; private set; }
    [SerializeField] private int numberOfLevels = 3;
    public int Level { get; private set; }
    private bool _isLevelActive = false;
    private int _numBallsInScene;
    private readonly int TimerScoreBonusFactor = 10;

    public event Action OnGameOver;
    public void GameOver()
    {
        Debug.Log("Game over");
        OnGameOver?.Invoke();
    }

    public static GameManager Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (!_isLevelActive)
        {
            return;
        }

        RemainingLevelTime -= Time.deltaTime;
        if (RemainingLevelTime <= 0f)
        {
            Debug.Log("Time's up!");
            LoseLife();
        }

        if (_numBallsInScene <= 0)
        {
            levelComplete();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    private void levelComplete()
    {
        Debug.Log("Level complete");

        _isLevelActive = false;
        AddScore((int)RemainingLevelTime * TimerScoreBonusFactor);

        if (Level < numberOfLevels)
        {
            LoadNextLevel();
        }
        else
        {
            Debug.Log("Game complete");
            // Game complete
        }
    }

    public void AddScore(int score)
    {
        Score += score;
        Debug.Log("Score: " + Score);
    }

    public void LoseLife()
    {
        Debug.Log("Lose a life");

        Lives--;
        Debug.Log("Lives: " + Lives);
        if (Lives <= 0)
        {
            GameOver();
        }
        else
        {
            Debug.Log("Resetting level");
            // Reset level
            loadLevel();
        }
    }

    private void resetGame()
    {
        Score = 0;
        Lives = _startingLives;
        _isLevelActive = false;
    }

    public void StartNewGame()
    {
        Debug.Log("Starting new game");
        resetGame();
        Level = 1;
        loadLevel();
    }

    private void loadLevel()
    {
        Debug.Log("Loading level " + Level);
        RemainingLevelTime = _levelTimer;
        SceneManager.LoadScene("Level" + Level);
        Invoke(nameof(setIsLevelActive), 2f);
    }

    private void setIsLevelActive()
    {
        _isLevelActive = true;
    }

    private void LoadNextLevel()
    {
        Level++;
        loadLevel();
    }

    public void OnBallSpawned()
    {
        _numBallsInScene++;
        Debug.Log("OnBallSpawned: Number of balls in scene: " + _numBallsInScene);
    }

    public void OnBallDestroyed()
    {
        if (_numBallsInScene > 0)
        {
            _numBallsInScene--;
        }
        Debug.Log("OnBallDestroyed: Number of balls in scene: " + _numBallsInScene);
    }

    public void QuitGame()
    {
        Debug.Log("Game closed");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void LoadMainMenu()
    {
        Debug.Log("Loading main menu");
        SceneManager.LoadScene("MainMenu");
    }
}
