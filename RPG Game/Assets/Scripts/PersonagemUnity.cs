using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemUnity : MonoBehaviour
{
    public int classe;
    private bool player;
    private PersonagemJogador personagem;
    void Start()
    {
        if(classe == 0)
        {
            personagem = new Ninja("Ninja");
        }
    }
    public PersonagemJogador getPersonagem() { return personagem; }
    public bool getPlayer(bool player) { return player; }
    public void setPlayer(bool player) { this.player = player; }
}
