using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PersonagemUnity : MonoBehaviour
{
    public int classe;
    private bool inBattle;
    private PersonagemJogador personagem;
    private Animator anim;
    private Rigidbody2D rb;
    private List<ItemObjeto> inventario =  new List<ItemObjeto>();
    private ItemObjeto arma;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("Direita");
        rb = GetComponent<Rigidbody2D>();
        anim.SetFloat("Classe", classe);

        if (classe == 0)
            personagem = new Guerreiro("Guerreiro");
        else if (classe == 1)
            personagem = new Mago("Mago");
        else if (classe == 2)
            personagem = new Assassino("Assassino");
    }
    private void Update()
    {
        int i = -1;
        if (!inBattle)
        {
            if (rb.velocity.x > 0)
                i = 1;
            else if (rb.velocity.x < 0)
                i = 2;
            else if (rb.velocity.y > 0)
                i = 3;
            else if (rb.velocity.y < 0)
                i = 4;
        }
        else
            rb.velocity = Vector2.zero;
        anim.SetInteger("MoveDir", i);
    }
    public PersonagemJogador getPersonagem() { return personagem; }
    public bool getInBattle() { return inBattle; }
    public void setInBattle(bool inBattle) { this.inBattle = inBattle; anim.Play("Direita"); }
    public List<ItemObjeto> Inventario { get => inventario; set => inventario = value; }
    public ItemObjeto Arma { get => arma; set => arma = value; }
}
