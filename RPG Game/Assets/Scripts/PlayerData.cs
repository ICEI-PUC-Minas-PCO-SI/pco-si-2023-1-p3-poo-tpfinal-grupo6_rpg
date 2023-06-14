using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    int level, xp, xpMax, levelUpDisponivel;

    void Start()
    {
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
            xpMax += 25;
            levelUpDisponivel++;
        }
    }
    public int LevelUpDisponivel { get => levelUpDisponivel; set => levelUpDisponivel = value; }
    public int Level { get => level; set => level = value; }
    public int Xp { get => xp; set => xp = value; }
    public int XpMax { get => xpMax; set => xpMax = value; }
}
