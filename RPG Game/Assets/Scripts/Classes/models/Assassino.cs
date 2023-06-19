using RpgGame.habilidades;
using RpgGame.itens;
using RpgGame.models;
using System.Collections.Generic;
using System.Linq;

public sealed class Assassino : PersonagemJogador
{
    public Assassino(string nome)
    {
        setNome(nome);
        atributo.Classe = 3;
        atributo.Hp = 25;
        atributo.MaxHp = atributo.Hp;
        atributo.Mana = 25;
        atributo.MaxMana = atributo.Mana;
        atributo.Atk = 4;
        atributo.Nivel = 1;
        habilidades = new List<Habilidade> { new ChuvaDeShuriken(), new OverKill()};
    }
    public override void LevelUp()
    {
        atributo.Nivel++;
        atributo.MaxHp += 2;
        atributo.Hp = atributo.MaxHp;
        atributo.MaxMana += 2;
        atributo.Mana = atributo.MaxMana;
        atributo.Atk += 6;
    }
}