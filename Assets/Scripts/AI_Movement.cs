using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Movement : MonoBehaviour
{
    public Ball ball;

    public float speed = 30F;

    public float lerpTweak = 2f;

    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Check if the Ball y position is > Paddle y position
        if (ball.transform.position.y > transform.position.y)
        {
            Vector2 direction = new Vector2(0, 1).normalized;
            // Lerp receives 2 vectors and smoothes the movement over time
            body.velocity = Vector2.Lerp(body.velocity, direction * speed, lerpTweak * Time.deltaTime);
        }
        else if (ball.transform.position.y < transform.position.y)
        {
            Vector2 direction = new Vector2(0, -1).normalized;
            body.velocity = Vector2.Lerp(body.velocity, direction * speed, lerpTweak * Time.deltaTime);
        }
        else
        {
            Vector2 direction = new Vector2(0, 0).normalized;
            body.velocity = Vector2.Lerp(body.velocity, direction * speed, lerpTweak * Time.deltaTime);
        }
    }

    //void Update() { }

}
