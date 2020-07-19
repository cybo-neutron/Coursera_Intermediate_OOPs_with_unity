using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene(1);
    }

    public void quit()
    {
        Application.Quit();
    }
        




}
