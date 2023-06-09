using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObjeto
{
    private string desc;
    private int valor;
    private Sprite img;
    private bool arma;
    private PersonagemUnity personagem;

    public ItemObjeto(string desc, int valor, Sprite img, bool arma)
    {
        this.desc = desc;
        this.valor = valor;
        this.img = img;
        this.Arma = arma;
    }

    public string Desc { get => desc; set => desc = value; }
    public int Valor { get => valor; set => valor = value; }
    public Sprite Img { get => img; set => img = value; }
    public bool Arma { get => arma; set => arma = value; }
    public PersonagemUnity Personagem { get => personagem; set => personagem = value; }
}
