using RpgGame.habilidades;
using RpgGame.itens;
using RpgGame.models;
using System.Collections.Generic;
using System.Linq;

public sealed class Mago : PersonagemJogador
{
    public Mago(string nome)
    {
        setNome(nome);
        atributo.Hp = 30;
        atributo.MaxHp = atributo.Hp;
        atributo.Mana = 40;
        atributo.MaxMana = atributo.Mana;
        atributo.Atk = 6;
        atributo.Xp = 0;
        atributo.MaxXp = 50;
        atributo.Nivel = 1;
        inventario = new List<Item> { new CajadoMadeira(), new PocaoCura(), new PocaoCura() };
        habilidades = new List<Habilidade> { new BolaDeFogo(), new AtaqueMagico(), new Obliterar() };
    }

    public override void LevelUp()
    {
        atributo.Nivel++;
        atributo.MaxHp += 3;
        atributo.Hp = atributo.MaxHp;
        atributo.MaxMana += 5;
        atributo.Mana = atributo.MaxMana;
        atributo.Atk += 3;
        atributo.MaxXp += 25;
    }
}
