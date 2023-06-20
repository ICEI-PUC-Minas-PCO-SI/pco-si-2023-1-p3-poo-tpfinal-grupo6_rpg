using RpgGame.habilidades;
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
        atributo.Classe = 1;
        atributo.Hp = 40;
        atributo.MaxHp = atributo.Hp;
        atributo.Mana = 25;
        atributo.MaxMana = atributo.Mana;
        atributo.Atk = 8;
        atributo.Nivel = 0;
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