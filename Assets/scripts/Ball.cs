using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    Rigidbody2D rb;
    Timer timer;

    float timeBeforeForce;

    BallSpawner ballSpawner;
    bool ballForced;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        timer = GetComponent<Timer>();
        
        ballSpawner = Camera.main.GetComponent<BallSpawner>();

        ballForced = false;


        timer.Run();

        timeBeforeForce = Time.time+1;
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        if (Time.time > timeBeforeForce && !ballForced)
        {
            forceBall();
            ballForced = true;
        }
    }
    void Update()
    {
        if(timer.Finished)
        {   
            SpawnBall();
            print("Timer finished");
            
            Destroy(this.gameObject);
        }

        if(transform.position.y<ScreenUtils.ScreenBottom)
        {
            //Debug.Log("Ball went down");
            
            SpawnBall();
            Destroy(this.gameObject);
        }

        
    }

    void SpawnBall()
    {
        
        ballSpawner.SpawnBall();
    }

    public void SetDirection(Vector2 direction)
    {
        float ballImpulse = ConfigurationUtils.BallImpulseForce;
        rb.velocity = new Vector2(direction.x * ballImpulse*Time.fixedDeltaTime, direction.y * ballImpulse*Time.fixedDeltaTime);
        //float ballVelocityVector = Mathf.Sqrt(Mathf.Pow(rb.velocity.x, 2) + Mathf.Pow(rb.velocity.y, 2));
        //rb.velocity = new Vector2(direction.x * ballVelocityVector, direction.y * ballVelocityVector);


    }

    void forceBall()
    {
        float angle = 60;

        Vector2 newDir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;

        rb.AddForce(newDir * ConfigurationUtils.BallImpulseForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }


}
