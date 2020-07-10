using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] Transform spawnPoint;
    Vector2 spawnLocationMin,spawnLocationMax;
    bool retry=true;

    float elapsedTime;

    float nextSpawnTime;
    private void Start()
    {
       
        CircleCollider2D collider = ball.GetComponent<CircleCollider2D>();
        float colliderWidth = collider.radius;
        float colliderHeight = collider.radius;
        spawnLocationMin = new Vector2(spawnPoint.position.x - 2*colliderWidth, spawnPoint.position.y - 2*colliderHeight);
        spawnLocationMin = new Vector2(spawnPoint.position.x + 2*colliderWidth, spawnPoint.position.y + 2*colliderHeight);
        retry = true;
        nextSpawnTime = Random.Range(ConfigurationUtils.minBallSpawnTime, ConfigurationUtils.maxBallSpawnTime);
        SpawnBall();

        elapsedTime = 0;


    }
    public void SpawnBall()
    {
        if (Physics2D.OverlapArea(spawnLocationMin, spawnLocationMax)==null && ConfigurationUtils.ballsLeft>0)
        {

            Instantiate(ball, spawnPoint.position, Quaternion.identity);
            //Instantiate(ball);

            retry = false;     
        }
        else
        {
            retry = true;
        }

    }

    private void Update()
    {
        //if (retry)
        //{
        //    SpawnBall();
        //}

        if (Time.time>nextSpawnTime)
        {
            nextSpawnTime=Time.time + Random.Range(ConfigurationUtils.minBallSpawnTime, ConfigurationUtils.maxBallSpawnTime);
            SpawnBall();
        }


        elapsedTime = elapsedTime + Time.deltaTime;
        print(elapsedTime);
    }

}
