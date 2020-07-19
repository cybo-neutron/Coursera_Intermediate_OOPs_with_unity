using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public  class EventManager :MonoBehaviour
{


   
    void Awake()
    {
        //pickupBlock.freezeEvent += freezeAction;



    }

    

    void freezeAction(float fTime)
    {
        Debug.Log("freeze");
        //freeze the paddle
        //Paddle.setFreezeEffect(true);
        
    }
    private void Update()
    {
        
    }



}
