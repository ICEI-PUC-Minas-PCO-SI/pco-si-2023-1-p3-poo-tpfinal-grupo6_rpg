using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoUnity : MonoBehaviour
{
    public int tier, quantidadeExtra;
    private PersonagemMonstro personagem;
    private PersonagemUnity target;
    private void LateUpdate()
    {
        if(FindObjectOfType<PersonagemUnity>() && personagem == null)
        {
            personagem = new CriaturaDaNoite(FindObjectOfType<PersonagemUnity>().getPersonagem());
        }
    }
    public PersonagemMonstro getPersonagem() { return personagem; }
    public void Atacar(PersonagemUnity[] p)
    {
        target = p[Random.Range(0, p.Length)];
        target.getPersonagem().atributo.Hp -= personagem.atributo.Atk;
    }
    public PersonagemUnity getTarget() { return target; }
    public int getQuantidadeExtra() { return quantidadeExtra; }
    public void setTarget(PersonagemUnity target) { this.target = target; }
}