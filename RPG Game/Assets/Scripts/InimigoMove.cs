using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoMove : MonoBehaviour
{
    Vector2 inicialPos;
    public float velMove, distanciaMax;
    bool follow, inBattle;
    Transform player;
    void Start()
    {
        inicialPos = transform.position;
    }
    void Update()
    {
        if (!inBattle)
        {
            if (follow)
            {
                if (Vector2.Distance(transform.position, inicialPos) >= distanciaMax)
                    follow = false;
                transform.position = Vector2.MoveTowards(transform.position, player.position, velMove * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, inicialPos, velMove * Time.deltaTime);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player == null)
                player = collision.GetComponent<Transform>();
            follow = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Manager manager = FindObjectOfType<Manager>();
            manager.setInimigo(GetComponent<InimigoMove>());
            manager.StartBattle();
            inBattle = true;
        }
    }
    public void setInBattle(bool battle)
    {
        inBattle = battle;
    }
}
