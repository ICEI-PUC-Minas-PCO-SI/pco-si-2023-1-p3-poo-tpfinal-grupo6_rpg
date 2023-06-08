using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObjeto
{
    private string desc;
    private int valor;
    private Sprite img;

    public ItemObjeto(string desc, int valor, Sprite img)
    {
        this.desc = desc;
        this.valor = valor;
        this.img = img;
    }

    public string Desc { get => desc; set => desc = value; }
    public int Valor { get => valor; set => valor = value; }
    public Sprite Img { get => img; set => img = value; }
}
