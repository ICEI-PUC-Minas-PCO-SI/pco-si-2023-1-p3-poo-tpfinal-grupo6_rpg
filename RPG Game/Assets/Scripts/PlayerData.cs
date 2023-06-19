using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    int level, xp, xpMax, levelUpDisponivel;
    List<ItemObjeto> mochila = new List<ItemObjeto>();

    void Start()
    {
        xpMax = 25;
        DontDestroyOnLoad(this.gameObject);
        GameObject aux = FindObjectOfType<MenuPrincipal>().gameObject;
        if (aux != null && !aux.Equals(gameObject))
            Destroy(aux);
    }
    public void SaveGame(int level, int xp)
    {
        this.level = level;
        this.xp = xp;
    }
    public void SetXp(int xpInserido)
    {
        xp += xpInserido;
        if (xp >= xpMax)
        {
            level++;
            xp = xp - xpMax;
            levelUpDisponivel++;
        }
    }
    public int LevelUpDisponivel { get => levelUpDisponivel; set => levelUpDisponivel = value; }
    public int Level { get => level; set => level = value; }
    public int Xp { get => xp; set => xp = value; }
    public int XpMax { get => xpMax; set => xpMax = value; }
    public List<ItemObjeto> Mochila { get => mochila; set => mochila = value; }

    public bool AdicionarItemMochila(ItemObjeto item)
    {
        if (mochila.Count < 12)
        {
            mochila.Add(item);
            return true;
        }
        else
            return false;
    }
}
