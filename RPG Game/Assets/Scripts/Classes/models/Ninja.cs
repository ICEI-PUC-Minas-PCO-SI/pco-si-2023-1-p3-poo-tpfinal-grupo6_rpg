using RpgGame.habilidades;
using RpgGame.itens;
using RpgGame.models;
using System.Collections.Generic;
using System.Linq;

public sealed class Ninja : PersonagemJogador
{
    public Ninja(string nome)
    {
        setNome(nome);
        atributo.Hp = 26;
        atributo.MaxHp = 26;
        atributo.Atk = 8;
        atributo.Xp = 0;
        atributo.Nivel = 1;
        inventario = new List<Item> { new AdagasDePedra(), new PocaoCura(), new PocaoCura() };
        habilidades = new List<Habilidade> { new AtaqueBasico(), new ChuvaDeShuriken() };
    }
    public override void LevelUp()
    {
        atributo.Nivel++;
        atributo.Hp += 2;
        atributo.MaxHp += 2;
        atributo.Atk += 4;
        atributo.Hp = atributo.MaxHp;
    }
}