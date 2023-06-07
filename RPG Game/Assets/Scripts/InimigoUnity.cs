using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoUnity : MonoBehaviour
{
    public int tier;
    private PersonagemMonstro personagem;
    void Start()
    {
        
    }
    private void LateUpdate()
    {
        if(FindObjectOfType<PersonagemUnity>() && personagem == null)
        {
            personagem = new CriaturaDaNoite(FindObjectOfType<PersonagemUnity>().getPersonagem());
            print(personagem.getNome());
        }
    }
    public PersonagemMonstro getPersonagem() { return personagem; }
}