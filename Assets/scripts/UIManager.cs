using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager: MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI ballsLeft;
    [SerializeField] GameObject pausePanel;

    static float score;
    static public int balls;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        balls = ConfigurationUtils.ballsLeft;
        pausePanel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        

        ScoreText.text = "Score: "+ score.ToString();
        ballsLeft.text = "Balls left: "+ balls.ToString();

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();

        }
    }



    static public void addScore(float s)
    {
        
        score += s;
   
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;

        pausePanel.SetActive(false);
    }

    public void RestartGame()
    {
        Scene scene=SceneManager.GetActiveScene();
        Time.timeScale = 1;
        SceneManager.LoadScene(scene.name);
    }

    public void QuitGame()
    {
        pausePanel.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
