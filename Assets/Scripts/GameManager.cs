using UnityEngine;
using UnityEngine.Events;
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
    public bool IsLevelActive { get; set; } = false;
    private int _numBallsInScene;
    private readonly int TimerScoreBonusFactor = 10;
    public int HighScore
    {
        get
        {
            return PlayerPrefs.GetInt("HighScore", 0);
        }
        private set
        {
            PlayerPrefs.SetInt("HighScore", value);
        }
    }

    public UnityEvent OnGameComplete = new UnityEvent();
    public UnityEvent OnGameOver = new UnityEvent();

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
        if (!IsLevelActive)
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
    }

    public void GameComplete()
    {
        Debug.Log("Game complete");
        if (Score > HighScore)
        {
            HighScore = Score;
        }

        OnGameComplete?.Invoke();
    }

    public void GameOver()
    {
        Debug.Log("Game over");
        if (Score > HighScore)
        {
            HighScore = Score;
        }

        OnGameOver?.Invoke();
    }

    private void levelComplete()
    {
        Debug.Log("Level complete");

        IsLevelActive = false;
        AddScore((int)RemainingLevelTime * TimerScoreBonusFactor);

        if (Level < numberOfLevels)
        {
            LoadNextLevel();
        }
        else
        {
            GameComplete();
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
            // load the current level again to reset it
            loadLevel();
        }
    }

    private void resetGame()
    {
        Debug.Log("Resetting game");
        Score = 0;
        Lives = _startingLives;
        IsLevelActive = false;
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
    }

    private void LoadNextLevel()
    {
        Level++;
        loadLevel();
    }

    public void OnBallSpawned()
    {
        _numBallsInScene++;
    }

    public void OnBallDestroyed()
    {
        if (_numBallsInScene > 0)
        {
            _numBallsInScene--;
        }
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
        IsLevelActive = false;
        SceneManager.LoadScene("MainMenu");
    }
}
