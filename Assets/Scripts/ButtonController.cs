using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    public void OnPlayGameButtonClick()
    {
        Debug.Log("PlayGame Clicked");
    }

    public void OnHighScoreButtonClick()
    {
        Debug.Log("HighScore Clicked");
    }
    
    public void OnExitButtonClick()
    {
        Debug.Log("Exit Clicked");
    }
    
}
