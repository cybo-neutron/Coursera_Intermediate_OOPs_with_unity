using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myTimer : MonoBehaviour
{
    float totalTime;
    bool running;
    bool started;

    private void Awake()
    {
        running = false;
        started = false;
        totalTime = 0f;
    }

    public void Run(float t)
    {
        totalTime += t;
        started = true;
        running = true;

    }

    public bool isRunning()
    {
        return running;
    }

    public void FixedUpdate()
    {
        if(totalTime>0)
        {
            totalTime -= Time.fixedDeltaTime;
        }
        else
        {
            running = false;
        }
    }


}
