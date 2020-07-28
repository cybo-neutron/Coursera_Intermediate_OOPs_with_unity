using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MenuName
{
    Difficulty,
    HighScore,
    MainMenu,
    HelpMenu,
    PauseMenu
}

public static class MenuManager 
{
   public static void GoToMenu(MenuName name)
    {
        switch(name)
        {
            case MenuName.Difficulty:
                GameObject mainmenuCanvas = GameObject.Find("MainMenuCanvas");
                mainmenuCanvas.SetActive(false);
                //Object.Instantiate(Resources.Load("DifficultyMenuP"),GameObject.Find("MainMenuCanvas").transform.position,Quaternion.identity);
                Object.Instantiate(Resources.Load("DificultyMenuCanvas"));
                break;
            case MenuName.HighScore:
                Object.Instantiate(Resources.Load("HighScoreMenu"));
                break;
            case MenuName.MainMenu:
                SceneManager.LoadScene("Menu");
                break;
            case MenuName.HelpMenu:
                Object.Instantiate(Resources.Load("HelpMenu"));
                break;
            case MenuName.PauseMenu:
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
        }
    }
}
