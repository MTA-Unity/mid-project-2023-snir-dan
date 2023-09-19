using TMPro;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject _highscorePanel;
    [SerializeField] private TMP_Text _highscoreText;

    void Start()
    {
        _highscorePanel.SetActive(false);
    }

    public void OnPlayGameButtonClick()
    {
        GameManager.Instance.StartNewGame();
    }

    public void OnHighScoreButtonClick()
    {
        _highscorePanel.SetActive(true);
        _highscoreText.text = GameManager.Instance.HighScore.ToString();
    }
    
    public void OnExitButtonClick()
    {
        GameManager.Instance.QuitGame();
    }
    
    public void OnExitHighscoreButtonClick()
    {
        _highscorePanel.SetActive(false);
    }

}
