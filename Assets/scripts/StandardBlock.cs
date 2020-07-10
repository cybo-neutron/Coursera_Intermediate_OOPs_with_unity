using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : blocks
{

    [SerializeField] SpriteRenderer[] sprites;


    protected override void Start()
    {
        base.Start();
        int randomNum = Random.Range(0, sprites.Length);

        SpriteRenderer sp = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();

        sp.color = sprites[randomNum].color;
    }

}
