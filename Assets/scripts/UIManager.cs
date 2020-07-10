using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager: MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI ballsLeft;

    static float score;
    static public int balls;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        balls = ConfigurationUtils.ballsLeft;

        
    }

    // Update is called once per frame
    void Update()
    {
        

        ScoreText.text = "Score: "+ score.ToString();
        ballsLeft.text = "Balls left: "+ balls.ToString();
    }



    static public void addScore(float s)
    {
        
        score += s;
        Debug.Log("Score: "+s);
    }
}
