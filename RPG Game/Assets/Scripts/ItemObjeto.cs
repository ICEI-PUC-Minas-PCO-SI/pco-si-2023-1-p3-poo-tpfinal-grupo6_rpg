using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObjeto : MonoBehaviour
{
    public string desc;
    public bool arma;
    public Vector3 valor; //x = vida; y = mana; z = ataque
    public Sprite img;
    private PersonagemUnity personagem;

    public ItemObjeto(string desc, Vector3 valor, Sprite img, bool arma)
    {
        this.desc = desc;
        this.valor = valor;
        this.img = img;
        this.Arma = arma;
    }

    public string Desc { get => desc; set => desc = value; }
    public Vector3 Valor { get => valor; set => valor = value; }
    public Sprite Img { get => img; set => img = value; }
    public bool Arma { get => arma; set => arma = value; }
    public PersonagemUnity Personagem { get => personagem; set => personagem = value; }
}
