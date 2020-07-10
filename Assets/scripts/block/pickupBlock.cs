using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupBlock : blocks
{
    [SerializeField] SpriteRenderer[] sprites;
    pickUpBlockType ballType;
    Dictionary<pickUpBlockType, SpriteRenderer> d = new Dictionary<pickUpBlockType, SpriteRenderer>();
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

    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ball"))
        {

            //Debug.Log(ballType);
            UIManager.addScore(blockPoints);
            Destroy(this.gameObject);
        }
    }


}
