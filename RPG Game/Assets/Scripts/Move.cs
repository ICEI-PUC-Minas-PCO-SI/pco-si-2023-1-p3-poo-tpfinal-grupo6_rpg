using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float x, y;
    Rigidbody2D rb;
    public float velMove;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal") * velMove;
        y = Input.GetAxisRaw("Vertical") * velMove;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(x, y);
    }
}
