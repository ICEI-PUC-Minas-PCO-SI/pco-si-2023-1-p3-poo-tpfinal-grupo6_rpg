﻿using RpgGame.habilidades;
using RpgGame.itens;
using RpgGame.models;
using RpgGame.view;
using System.Collections.Generic;
using System.Linq;

public sealed class Guerreiro : PersonagemJogador
{
    public Guerreiro(string nome)
    {
        this.setNome(nome);
        atributo.Hp = 40;
        atributo.MaxHp = atributo.Hp;
        atributo.Mana = 25;
        atributo.MaxMana = atributo.Mana;
        atributo.Atk = 8;
        atributo.Nivel = 1;
        inventario = new List<Item> { new EspadaMadeira(), new PocaoCura(), new PocaoCura() };
        habilidades = new List<Habilidade> { new CorteRapido() };
    }
    public override void LevelUp()
    {
        atributo.Nivel++;
        atributo.MaxHp += 5;
        atributo.Hp = atributo.MaxHp;
        atributo.MaxMana += 3;
        atributo.Mana = atributo.MaxMana;
        atributo.Atk += 3;
    }
}