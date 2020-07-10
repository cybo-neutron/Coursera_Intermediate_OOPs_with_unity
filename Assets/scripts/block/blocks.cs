using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blocks : MonoBehaviour
{
   
    protected float blockPoints;
    protected virtual void Start()
    {
        blockPoints = ConfigurationUtils.blockPoints;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Ball"))
        {
            UIManager.addScore(blockPoints);
            Destroy(this.gameObject);
        }
    }
}
