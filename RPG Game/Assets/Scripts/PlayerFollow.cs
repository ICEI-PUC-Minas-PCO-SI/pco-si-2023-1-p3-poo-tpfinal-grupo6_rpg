using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    PlayerMove player;
    void Start()
    {
        player = FindObjectOfType<PlayerMove>();
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, player.transform.position) >= 1)
            transform.position = Vector2.Lerp(transform.position, player.transform.position, player.getVelMove() * Time.deltaTime);
    }
}
