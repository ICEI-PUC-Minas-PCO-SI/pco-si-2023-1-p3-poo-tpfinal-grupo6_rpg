using RpgGame.models;
using RpgGame.view;
using System.Collections.Generic;
using System.Linq;

internal class CriaturaDaNoite : PersonagemMonstro
{
    public CriaturaDaNoite(IStatus status)
    {
        tier = Operacoes.GerarTier();
        setNome (Operacoes.GeradorDeNome(tier));
        int nivel = Operacoes.GerarNivel(tier, status);
        int maxHp = Operacoes.RealizarFunc(tier, nivel, Operacoes.GerarHp);
        int atk = Operacoes.RealizarFunc(tier, nivel, Operacoes.GerarAtk);
        int xp = Operacoes.RealizarFunc(tier, nivel, Operacoes.GerarXp);
        habilidades = new List<Habilidade>(Operacoes.GerarHab(tier, nivel));
        atributo = new Atributos { Nivel = nivel, MaxHp = maxHp, Hp = maxHp, Atk = atk};
    }
}