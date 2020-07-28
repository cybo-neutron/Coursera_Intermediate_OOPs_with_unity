using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void HandlePlayButtonEvent()
    {
        MenuManager.GoToMenu(MenuName.Difficulty);
    }

    public void HandleHighScoreButton()
    {
        MenuManager.GoToMenu(MenuName.HighScore);
    }

    public void HandleHelpButton()
    {
        MenuManager.GoToMenu(MenuName.HelpMenu);
    }

    public void HandleQuitButton()
    {
        Application.Quit();
    }
}
