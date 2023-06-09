using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoMove : MonoBehaviour
{
    Vector2 inicialPos, targetMove, posPerseguir;
    float velMove, velMoveIdle, distanciaMax, tempoEndBattle;
    bool follow, inBattle, endBattle, voltarInicio;
    public bool boss;
    Transform player;
    void Start()
    {
        inicialPos = transform.position;
        targetMove = new Vector2(Random.Range(inicialPos.x - 5, inicialPos.x + 5), Random.Range(inicialPos.y - 5, inicialPos.y + 5));
        velMove = 5;
        velMoveIdle = Random.Range(0.5f, 1.2f);
        distanciaMax = 2.8f;
        tempoEndBattle = 2;
    }
    void Update()
    {
        if (!inBattle && !endBattle)
        {
            if (follow)
            {
                if (voltarInicio)
                {
                    transform.position = Vector2.MoveTowards(transform.position, inicialPos, velMove * Time.deltaTime);
                    if (Vector2.Distance(transform.position, inicialPos) <= 0.15f)
                    {
                        voltarInicio = false;
                        follow = false;
                    }
                }
                else
                {
                    if (Vector2.Distance(transform.position, posPerseguir) > distanciaMax)
                    {
                        voltarInicio = true;
                    }
                    transform.position = Vector2.MoveTowards(transform.position, player.position, velMove * Time.deltaTime);
                }
            }
            else
            {
                if (Vector2.Distance(transform.position, targetMove) <= 0.15f)
                    targetMove = new Vector2(Random.Range(inicialPos.x - 0.5f, inicialPos.x + 0.5f),
                        Random.Range(inicialPos.y - 0.5f, inicialPos.y + 0.5f));
                transform.position = Vector2.MoveTowards(transform.position, targetMove, velMoveIdle * Time.deltaTime);
            }
        }
        if (endBattle)
            StartCoroutine(EndBattle());
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !inBattle && !endBattle && !follow && !voltarInicio)
        {
            posPerseguir = transform.position;
            if (player == null)
                player = collision.GetComponent<Transform>();
            follow = true;
            voltarInicio = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && !inBattle && !endBattle)
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
        if (!battle)
            endBattle = true;
    }
    public void resetPosition()
    {
        transform.position = inicialPos;
    }
    public float getVelMove()
    {
        return velMove;
    }
    IEnumerator EndBattle()
    {
        yield return new WaitForSeconds(tempoEndBattle);
        follow = false;
        endBattle = false;
    }
}
