using RpgGame.models;
using RpgGame.view;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal class CriaturaDaNoite : PersonagemMonstro
{
    public CriaturaDaNoite(IStatus status, int quantidadeExtra, bool boss)
    {
        tier = Operacoes.GerarTier();
        setNome (Operacoes.GeradorDeNome(tier));
        int nivel = Operacoes.GerarNivel(tier, status);
        int maxHp, atk;
        if (boss)
        {
            atk = 15;
            maxHp = 60;
        }
        else
        {
            if (quantidadeExtra <= 1)
            {
                atk = Random.Range(4, 8);
                maxHp = Random.Range(16, 35);
            }
            else
            {
                atk = Random.Range(3, 6);
                maxHp = Random.Range(10, 25);
            }
        }
        habilidades = new List<Habilidade>(Operacoes.GerarHab(tier, nivel));
        atributo = new Atributos { Nivel = nivel, MaxHp = maxHp, Hp = maxHp, Atk = atk};
    }
}