using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        float angle = 20;
        //Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
        Vector2 newDir = new Vector2(0, 1);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(newDir*ConfigurationUtils.BallImpulseForce*Time.fixedDeltaTime, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDirection(Vector2 direction)
    {
        float ballImpulse = ConfigurationUtils.BallImpulseForce;
        rb.velocity = new Vector2(direction.x * ballImpulse*Time.fixedDeltaTime, direction.y * ballImpulse*Time.fixedDeltaTime);
        //float ballVelocityVector = Mathf.Sqrt(Mathf.Pow(rb.velocity.x, 2) + Mathf.Pow(rb.velocity.y, 2));
        //rb.velocity = new Vector2(direction.x * ballVelocityVector, direction.y * ballVelocityVector);


    }
}
