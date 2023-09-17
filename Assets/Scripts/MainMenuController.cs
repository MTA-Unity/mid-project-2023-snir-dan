using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void OnPlayGameButtonClick()
    {
        Debug.Log("PlayGame Clicked");
        GameManager.Instance.StartNewGame();
    }

    public void OnHighScoreButtonClick()
    {
        Debug.Log("HighScore Clicked");
    }
    
    public void OnExitButtonClick()
    {
        Debug.Log("Exit Clicked");
        GameManager.Instance.QuitGame();
    }
    
}
