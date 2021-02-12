using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public float speed = 30F;

    private Rigidbody2D body;

    private AudioSource audioSource;

    private int clipCounter = 0;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = Vector2.right * speed;
    }

    //void Update() { }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Paddle Check
        if (collision.gameObject.name == "Player" || collision.gameObject.name == "AI")
        {
            manageCollisionPaddle(collision);
            SoundManager.Instance.call(SoundManager.Instance.ballHitsPaddle);
        }

        //Horizontal Bounce Check
        if (collision.gameObject.name == "Vertical Wall Up" || collision.gameObject.name == "Vertical Wall Down")
        {
            SoundManager.Instance.call(SoundManager.Instance.ballHitsWall);
        }

        //Goal Check
        if (collision.gameObject.name == "Horizontal Wall Left" || collision.gameObject.name == "Horizontal Wall Right")
        {
            if      (clipCounter == 0) { SoundManager.Instance.call(SoundManager.Instance.goalClip1); }
            else if (clipCounter == 1) { SoundManager.Instance.call(SoundManager.Instance.goalClip2); }
            else if (clipCounter == 2) { SoundManager.Instance.call(SoundManager.Instance.goalClip3); }
            else if (clipCounter == 3) { SoundManager.Instance.call(SoundManager.Instance.goalClip4); }
            else   /*clipCounter == 4*/{ SoundManager.Instance.call(SoundManager.Instance.goalClip5); }
            clipCounter++;  clipCounter%= 5;
            if (collision.gameObject.name == "Horizontal Wall Right")
            {
                increaseTextUIScore("PlayerScore");
            }
            else if (collision.gameObject.name == "Horizontal Wall Left")
            {
                increaseTextUIScore("AIScore");
            }
            transform.position = new Vector2(0, 0);
        }
    }

    private void manageCollisionPaddle(Collision2D col)
    {
        float y = (transform.position.y - col.transform.position.y) / col.collider.bounds.size.y;
        Vector2 direction = new Vector2();
        if (col.gameObject.name == "Player")
        {
            direction = new Vector2(1, y).normalized;
        }
        if (col.gameObject.name == "AI")
        {
            direction = new Vector2(-1, y).normalized;
        }
        body.velocity = direction * speed;
        SoundManager.Instance.call(SoundManager.Instance.ballHitsPaddle);
    }

    void increaseTextUIScore(string textUIName)
    {
        var textUIComp = GameObject.Find(textUIName).GetComponent<Text>();
        int score = int.Parse(textUIComp.text);
        score++;
        textUIComp.text = score.ToString();
    }
}