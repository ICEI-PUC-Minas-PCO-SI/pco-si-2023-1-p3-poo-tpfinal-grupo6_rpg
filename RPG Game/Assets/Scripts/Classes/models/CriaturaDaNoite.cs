using RpgGame.models;
using RpgGame.view;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal class CriaturaDaNoite : PersonagemMonstro
{
    public CriaturaDaNoite(IStatus status, int quantidadeExtra)
    {
        tier = Operacoes.GerarTier();
        setNome (Operacoes.GeradorDeNome(tier));
        int nivel = Operacoes.GerarNivel(tier, status);
        int maxHp, atk;
        if (quantidadeExtra <= 1)
        {
            atk = Random.Range(3, 8);
            maxHp = Random.Range(10, 25);
        }
        else
        {
            atk = Random.Range(2, 4);
            maxHp = Random.Range(5, 15);
        }

        int xp = Operacoes.RealizarFunc(tier, nivel, Operacoes.GerarXp);
        habilidades = new List<Habilidade>(Operacoes.GerarHab(tier, nivel));
        atributo = new Atributos { Nivel = nivel, MaxHp = maxHp, Hp = maxHp, Atk = atk};
    }
}