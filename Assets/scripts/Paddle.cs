using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    Rigidbody2D rb;
    float paddleWidth;
    const float BounceAngleHalfRange=60;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        paddleWidth = GetComponent<BoxCollider2D>().size.x / 2;
        Debug.Log(paddleWidth);
        Debug.Log(ScreenUtils.ScreenLeft);
        Debug.Log(ScreenUtils.ScreenRight);
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void FixedUpdate()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), 0);
        Vector2 newPos = getPositon() + moveInput * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.fixedDeltaTime;
        //rb.MovePosition(new Vector2(calculateClampedX(newPos.x),newPos.y));
        newPos.x = calculateClampedX(newPos.x);
        //Debug.Log(newPos.x);
        rb.MovePosition(newPos);
    }

    Vector2 getPositon()
    {
        return (Vector2)transform.position;
    }

    float calculateClampedX(float x)
    {
        if (x - paddleWidth < ScreenUtils.ScreenLeft)
            return ScreenUtils.ScreenLeft + paddleWidth;
        if (x + paddleWidth > ScreenUtils.ScreenRight)
            return ScreenUtils.ScreenRight - paddleWidth;
        return x;

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                paddleWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }

}
