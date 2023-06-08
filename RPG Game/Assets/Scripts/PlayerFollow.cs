using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    PlayerMove player;
    Rigidbody2D rb;
    Vector2 dir;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMove>();
    }
    private void FixedUpdate()
    {
        dir.x = player.transform.position.x;
        dir.y = player.transform.position.y;
        Vector2 velocity = rb.velocity;

        //Horizontal
        if (Mathf.Abs(dir.x - transform.position.x) >= 1)
        {
            if (dir.x >= transform.position.x)
                velocity.x = 1;
            else
                velocity.x = -1;
        }
        else
            velocity.x = 0;

        //Vertical
        if (Mathf.Abs(dir.y - transform.position.y) >= 1)
        {
            if (dir.y >= transform.position.y)
                velocity.y = 1;
            else
                velocity.y = -1;
        }
        else
            velocity.y = 0;

        rb.velocity = velocity.normalized * Time.deltaTime * (player.getVelMove() * 100);
    }
}
