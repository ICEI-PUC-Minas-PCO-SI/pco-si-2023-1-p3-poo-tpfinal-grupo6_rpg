using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    int level, xp, xpMax, levelUpDisponivel;
    List<ItemObjeto> mochila = new List<ItemObjeto>();
    private int[] playerSelecionado = new int[2];

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        xpMax = 25;
        DontDestroyOnLoad(this.gameObject);
        GameObject aux = FindObjectOfType<PlayerData>().gameObject;
        if (aux != null && !aux.Equals(gameObject))
            Destroy(aux);
    }
    public void SetXp(int xpInserido)
    {
        xp += xpInserido;
        if (xp >= xpMax)
        {
            xp = xp - xpMax;
            levelUpDisponivel++;
        }
    }
    public int LevelUpDisponivel { get => levelUpDisponivel; set => levelUpDisponivel = value; }
    public int Level { get => level; set => level = value; }
    public int Xp { get => xp; set => xp = value; }
    public int XpMax { get => xpMax; set => xpMax = value; }
    public List<ItemObjeto> Mochila { get => mochila; set => mochila = value; }
    public int[] PlayerSelecionado { get => playerSelecionado; set => playerSelecionado = value; }

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
