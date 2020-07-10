using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Timer : MonoBehaviour
{
    bool running;
    bool started;
    
    [SerializeField]public float totalTime;
    [SerializeField]float elapsedTime;

    private void Start()
    {
        totalTime = ConfigurationUtils.BallTimer;

    }
    public bool Running
    {
        get
        {
            return running;
        }
    }

    public bool Finished
    {
        get
        {
            return (started && !running);

        }
    }

    public float Duration
    {
        set
        {
            if(!running)
            {
                totalTime = value;
            }
        }
    }



    public void Run()
    {
        print("run");
        print(totalTime);
        if(totalTime>0f)
        {
            print("Running");
            running = true;
            started = true;
            elapsedTime = 0f;
        }
    }

    private void Update()
    {
      if(running)
        {
            elapsedTime += Time.deltaTime;
            if(elapsedTime>=totalTime)
            {
                running = false;
            }
        }
    }

}
