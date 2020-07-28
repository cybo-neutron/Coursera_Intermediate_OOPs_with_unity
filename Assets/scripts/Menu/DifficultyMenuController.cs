using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyMenuController : MonoBehaviour
{

    public void HandleEasyButton()
    {
        SceneManager.LoadScene("gameplay");
    }
    public void HandleBackButton()
    {
        MenuManager.GoToMenu(MenuName.MainMenu);
    }
}
