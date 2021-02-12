using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 30;

    private void FixedUpdate()
    {
        float dirc = Input.GetAxisRaw("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, dirc) * speed;
    }

    void Start() { }

    //void Update() { }
}
