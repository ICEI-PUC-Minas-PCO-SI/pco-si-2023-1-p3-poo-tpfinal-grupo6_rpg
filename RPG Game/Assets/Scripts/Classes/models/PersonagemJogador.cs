using RpgGame.Interface;
using RpgGame.models;
using RpgGame.view;
using System.Collections.Generic;
using UnityEngine;

public abstract class PersonagemJogador : Personagem, IStatus
{
    public List<Habilidade>? habilidades { get; protected set; }
    public Atributos atributo { get; protected set; } = new Atributos();

    public void UsarItem(ItemObjeto item)
    {
        if (!item.arma)
        {
            if (item.valor.x > 0)
                atributo.Hp += (int)(atributo.MaxHp * item.valor.x);
            if (atributo.Hp > atributo.MaxHp)
                atributo.Hp = atributo.MaxHp;
            if (item.valor.y > 0)
                atributo.Mana += (int)(atributo.MaxMana * item.valor.y);
            if (atributo.Mana > atributo.MaxMana)
                atributo.Mana = atributo.MaxMana;

            atributo.Atk += (int)item.valor.z;
        }
    }
    public void AprenderHab(Habilidade hab)
    {
        if (habilidades.Count < 4)
        {
            habilidades.Add(hab);
        }
        else
        {
            //Upgrade de habilidade;
            //Substituir hablidade (pega o msm nivel da habilidade anterior)
            Operacoes.SubstituirHabilidade(habilidades, hab);
        }
    }
    public int DarDano(int hab, float arma)
    {
        if (hab < 0)
            return (int)(atributo.Atk * arma);

        atributo.Mana -= habilidades[hab].Custo;
        return (int)(atributo.Atk * habilidades[hab].Multiplicador * 1.6f * arma);
    }
    public abstract void LevelUp();

}
