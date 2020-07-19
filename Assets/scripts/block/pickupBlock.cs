using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class pickupBlock : blocks
{
    [SerializeField] SpriteRenderer[] sprites;
    pickUpBlockType ballType;
    Dictionary<pickUpBlockType, SpriteRenderer> d = new Dictionary<pickUpBlockType, SpriteRenderer>();
    public float freezeTime;
    public float speed;

    public delegate void freezeDelegate(float fTime);
    public static event freezeDelegate freezeEvent;

    public delegate void speedDelegate(float speedX, float sTime);
    public static event speedDelegate speedEvent;

    protected override void Start()
    {
        base.Start();

        blockPoints = ConfigurationUtils.pickupBlockPoints;

        d.Add(pickUpBlockType.freeze, sprites[0]);
        d.Add(pickUpBlockType.speedup, sprites[1]);

        int randomNum = UnityEngine.Random.Range(0, sprites.Length);
        if (randomNum == 0)
            ballType = pickUpBlockType.freeze;
        else
            ballType = pickUpBlockType.speedup;

        SpriteRenderer sp = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();

        sp.color = d[ballType].color;

        freezeTime = ConfigurationUtils.freezerTime;

    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ball"))
        {

            //Debug.Log(ballType);

            //Debug.Log("hit block");

            if(ballType==pickUpBlockType.freeze)
            {
                //invoke freeze event
                try
                {
                    //EventManager.freeze.Invoke(ConfigurationUtils.freezerTime);
                    if(freezeEvent!=null)
                    freezeEvent(ConfigurationUtils.freezerTime);
                    
                }
                catch(Exception e)
                {
                    Debug.Log("Could not invoke: " + e.Message);
                }
                Debug.Log(ballType);
            }
            else if(ballType==pickUpBlockType.speedup)
            {
                //invoke speedup event
                //EventManager.speedup.Invoke(ConfigurationUtils.speedupTime, ConfigurationUtils.speedX);
                if(speedEvent!=null)
                {
                    speedEvent(ConfigurationUtils.speedX, ConfigurationUtils.speedupTime);
                }

                Debug.Log(ballType);


            }
            UIManager.addScore(blockPoints);
            Destroy(this.gameObject);
        }
    }


  

}
