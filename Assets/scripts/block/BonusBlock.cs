using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : blocks
{

    [SerializeField] SpriteRenderer[] sprites;
    protected override void Start()
    {
        base.Start();
        blockPoints = ConfigurationUtils.bonusBlockPoints;

        int randomNum = Random.Range(0, sprites.Length);

        SpriteRenderer sp = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();

        sp.color = sprites[randomNum].color;
    }

  
}
