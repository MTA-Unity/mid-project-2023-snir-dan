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

    // [SerializeField] private GameObject _pauseMenu;
    // [SerializeField] private GameObject _gameOverMenu;
    // [SerializeField] private GameObject _levelCompleteMenu;

    // Start is called before the first frame update
    void Start()
    {
        // _pauseMenu.SetActive(false);
        // _gameOverMenu.SetActive(false);
        // _levelCompleteMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Escape))
        // {
        //     _pauseMenu.SetActive(true);
        //     Time.timeScale = 0f;
        // }

        // if (GameManager.Instance.IsGameOver)
        // {
        //     _gameOverMenu.SetActive(true);
        //     Time.timeScale = 0f;
        // }

        // if (GameManager.Instance.IsLevelComplete)
        // {
        //     _levelCompleteMenu.SetActive(true);
        //     Time.timeScale = 0f;
        // }

        _levelNumberText.text = $"Level: {GameManager.Instance.Level}";
        _scoreText.text = $"Score: {GameManager.Instance.Score}";
        _livesText.text = $"Lives: {GameManager.Instance.Lives}";
        _timerText.text = $"Time: {GameManager.Instance.RemainingLevelTime:F1}";
    }

    // public void OnResumeButtonClick()
    // {
    //     // _pauseMenu.SetActive(false);
    //     Time.timeScale = 1f;
    // }

    // public void OnRestartButtonClick()
    // {
    //     // _gameOverMenu.SetActive(false);
    //     // _levelCompleteMenu.SetActive(false);
    //     Time.timeScale = 1f;
    //     GameManager.Instance.StartNewGame();
    // }

    // public void OnMainMenuButtonClick()
    // {
    //     // _gameOverMenu.SetActive(false);
    //     // _levelCompleteMenu.SetActive(false);
    //     Time.timeScale = 1f;
    //     GameManager.Instance.LoadMainMenu();
    // }

    // public void OnQuitButtonClick()
    // {
    //     GameManager.Instance.QuitGame();
    // }

    // public void OnNextLevelButtonClick()
    // {
    //     // _levelCompleteMenu.SetActive(false);
    //     Time.timeScale = 1f;
    //     GameManager.Instance.LoadNextLevel();
    // }

    // public void OnPlayButtonClick()
    // {
    //     GameManager.Instance.StartNewGame();
    // }
}
