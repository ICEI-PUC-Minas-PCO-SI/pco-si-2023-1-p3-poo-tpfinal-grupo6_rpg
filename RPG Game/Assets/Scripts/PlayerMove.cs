using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector2 move;
    Rigidbody2D rb;
    float velMove;
    void Start()
    {
        velMove = 3.8f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        rb.velocity = move.normalized * Time.deltaTime * (velMove * 100);
    }
    public float getVelMove()
    {
        return velMove;
    }
}
