using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        _pauseMenu.SetActive(false);
        _gameOverMenu.SetActive(false);
        GameManager.Instance.OnGameOver += OnGameOver;
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
        _gameOverMenu.SetActive(true);
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
