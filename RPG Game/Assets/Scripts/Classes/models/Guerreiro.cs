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
        atributo.Hp = 36;
        atributo.MaxHp = 36;
        atributo.Atk = 6;
        atributo.Xp = 0;
        atributo.Nivel = 100;
        inventario = new List<Item> { new EspadaMadeira(), new PocaoCura(), new PocaoCura() };
        habilidades = new List<Habilidade> { new AtaqueBasico(), new CorteRapido() };
    }
    public override void LevelUp()
    {
        atributo.Nivel++;
        atributo.Hp += 4;
        atributo.MaxHp += 4;
        atributo.Atk += 2;
        atributo.Hp = atributo.MaxHp;
    }
}