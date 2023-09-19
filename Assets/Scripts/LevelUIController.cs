using TMPro;
using UnityEngine;

public class LevelUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelNumberText;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _livesText;
    [SerializeField] private TMP_Text _timerText;

    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private GameObject _winningPanel;
    [SerializeField] private TMP_Text _WinningPanelScoreText;

    void Start()
    {
        _pauseMenu.SetActive(false);
        _gameOverMenu.SetActive(false);
        _winningPanel.SetActive(false);
        GameManager.Instance.OnGameOver.AddListener(OnGameOver);
        GameManager.Instance.OnGameComplete.AddListener(OnGameComplete);
        GameManager.Instance.IsLevelActive = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        _levelNumberText.text = $"Level: {GameManager.Instance.Level}";
        _scoreText.text = $"Score: {GameManager.Instance.Score}";
        _livesText.text = $"Lives: {GameManager.Instance.Lives}";
        _timerText.text = $"Time: {GameManager.Instance.RemainingLevelTime:F1}";
    }

    private void OnGameOver()
    {
        Debug.Log("In OnGameOver method in LevelUIController.cs");
        _gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnGameComplete()
    {
        Debug.Log("In OnGameComplete method in LevelUIController.cs");
        _winningPanel.SetActive(true);
        _WinningPanelScoreText.text = GameManager.Instance.Score.ToString();

        Time.timeScale = 0f;
    }

    public void OnResumeButtonClick()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnRestartButtonClick()
    {
        _gameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        GameManager.Instance.StartNewGame();
    }

    public void OnMainMenuButtonClick()
    {
        Time.timeScale = 1f;
        GameManager.Instance.LoadMainMenu();
    }

    public void OnQuitButtonClick()
    {
        GameManager.Instance.QuitGame();
    }
}
