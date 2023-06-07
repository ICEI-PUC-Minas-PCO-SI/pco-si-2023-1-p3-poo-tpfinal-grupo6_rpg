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
        atributo.MaxHp = 30;
        atributo.Atk = 7;
        atributo.Xp = 0;
        atributo.Nivel = 1;
        inventario = new List<Item> { new CajadoMadeira(), new PocaoCura(), new PocaoCura() };
        habilidades = new List<Habilidade> { new AtaqueBasico(), new AtaqueMagico() };
    }

    public override void LevelUp()
    {
        atributo.Nivel++;
        atributo.Hp += 3;
        atributo.MaxHp += 3;
        atributo.Atk += 3;
        atributo.Hp = atributo.MaxHp;
    }
}
