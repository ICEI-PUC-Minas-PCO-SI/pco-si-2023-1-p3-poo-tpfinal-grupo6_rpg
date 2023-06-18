using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoUnity : MonoBehaviour
{
    int quantidadeExtra;
    private PersonagemMonstro personagem;
    private PersonagemUnity target;
    public SpriteRenderer vida;
    private void Start()
    {
        quantidadeExtra = Random.Range(0, 4);
    }
    private void Update()
    {
        if(personagem != null)
        {
            if (vida.gameObject.activeSelf)
                vida.size = new Vector2((float)personagem.atributo.Hp / personagem.atributo.MaxHp, 1);
            if (personagem.atributo.Hp <= 0)
            {
                FindObjectOfType<BattleManager>().inimigoMorto(GetComponent<InimigoUnity>());
                Destroy(gameObject);
            }
        }
    }
    private void LateUpdate()
    {
        if(FindObjectOfType<PersonagemUnity>() && personagem == null)
            personagem = new CriaturaDaNoite(FindObjectOfType<PersonagemUnity>().getPersonagem(), quantidadeExtra);
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