using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class pickupBlock : blocks
{
    [SerializeField] SpriteRenderer[] sprites;
    pickUpBlockType ballType;
    Dictionary<pickUpBlockType, SpriteRenderer> d = new Dictionary<pickUpBlockType, SpriteRenderer>();
    freezeEffect freezeEvent = new freezeEffect();
    speedupEffect speedupEvent = new speedupEffect();

    protected override void Start()
    {
        base.Start();

        blockPoints = ConfigurationUtils.pickupBlockPoints;

        d.Add(pickUpBlockType.freeze, sprites[0]);
        d.Add(pickUpBlockType.speedup, sprites[1]);

        int randomNum = Random.Range(0, sprites.Length);
        if (randomNum == 0)
            ballType = pickUpBlockType.freeze;
        else
            ballType = pickUpBlockType.speedup;

        SpriteRenderer sp = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();

        sp.color = d[ballType].color;
        switch(ballType)
        {
            case pickUpBlockType.freeze:
                EventManager.addFreezeInvoker(this);
                break;
            case pickUpBlockType.speedup:
                EventManager.addspeedupInvoker(this);
                break; 
        }
        

    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ball"))
        {

            //Debug.Log(ballType);
            UIManager.addScore(blockPoints);
            Destroy(this.gameObject);

            switch(ballType)
            {
                case pickUpBlockType.freeze:
                    freezeEvent.Invoke(ConfigurationUtils.freezeTime);
                    break;
                case pickUpBlockType.speedup:
                    speedupEvent.Invoke(ConfigurationUtils.speedupTime, ConfigurationUtils.speedX);
                    break;
            }
        }
    }

    public void addlistener(UnityAction<float> listener)
    {
        freezeEvent.AddListener(listener);
    }
    public void addlistener(UnityAction<float,float> listener)
    {
        speedupEvent.AddListener(listener);
    }
    

}
