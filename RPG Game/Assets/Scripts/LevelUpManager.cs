using RpgGame.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LevelUpManager : MonoBehaviour
{
    public GameObject firstButton, hudInGame, hudLevelUp;
    Manager manager;
    PlayerData playerData;
    List<Habilidade> allSkills;
    List<Habilidade> sortedSkills;
    Habilidade habilidadeSelecionada;
    PersonagemJogador pVez;
    public TextMeshProUGUI[] descUpgrade;
    int atrType;
    bool substituirHab, inUpgrade , vezP2;
    public Image face;
    public Sprite[] facePlayers;

    void Start()
    {
        manager = GetComponent<Manager>();
        playerData = FindObjectOfType<PlayerData>();
        allSkills = CarregarHabilidades();
    }

    void Update()
    {
        if (Input.GetKeyDown("l") && playerData.LevelUpDisponivel > 0 && !inUpgrade)
        {
            pVez = manager.P1.getPersonagem();
            CarregarHud(pVez);
            hudInGame.SetActive(false);
            hudLevelUp.SetActive(true);
            manager.getEventSystem().SetSelectedGameObject(firstButton);
            manager.getEventSystem().sendNavigationEvents = true;
            substituirHab = false;
            inUpgrade = true;
            vezP2 = false;
            manager.movePlayer(false);
        }
        if (Input.GetKeyDown("q"))
            playerData.SetXp(playerData.XpMax);
    }
    public static List<Habilidade> CarregarHabilidades()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        var habilidades = assembly.GetTypes().Where(Type => Type.IsSubclassOf(typeof(Habilidade)));
        List<Habilidade> allSkill = new List<Habilidade>();
        foreach (Type subclass in habilidades)
        {
            Habilidade habilidade = (Habilidade)Activator.CreateInstance(subclass);
            allSkill.Add(habilidade);
        }
        return allSkill;
    }
    public void CarregarHud(PersonagemJogador p)
    {
        face.sprite = facePlayers[p.atributo.Classe-1];
        if (substituirHab)
        {
            descUpgrade[0].text = p.habilidades[0].Nome;
            descUpgrade[1].text = p.habilidades[1].Nome;
            descUpgrade[2].text = p.habilidades[2].Nome;
        }
        else
        {
            List<Habilidade> habClasse = new List<Habilidade>();
            sortedSkills = new List<Habilidade>();

            for (int i = 0; i < allSkills.Count; i++)
            {
                if (allSkills[i].ClassType == p.atributo.Classe)
                    habClasse.Add(allSkills[i]);
            }
            sortedSkills.Add(habClasse[Random.Range(0, habClasse.Count)]);
            sortedSkills.Add(habClasse[Random.Range(0, habClasse.Count)]);
            descUpgrade[0].text = sortedSkills[0].Nome;
            descUpgrade[1].text = sortedSkills[1].Nome;
            atrType = Random.Range(0, 3);
            if (atrType == 0)
                descUpgrade[2].text = "Aumente sua <color=#FF0D49>Vida</color>";
            if (atrType == 1)
                descUpgrade[2].text = "Aumente sua <color=#01F4FF>Mana</color>";
            else
                descUpgrade[2].text = "Aumente seu <color=#FF9C00>Ataque</color>";
        }
    }
    public void SelecionarUpgrade(int i)
    {
        if (substituirHab)
        {
            pVez.habilidades[i] = habilidadeSelecionada;
            substituirHab = false;
        }
        else
        {
            if (i == 2)
            {
                if (atrType == 0)
                    pVez.atributo.MaxHp += 3;
                if (atrType == 1)
                    pVez.atributo.MaxMana += 3;
                else
                    pVez.atributo.Atk += 3;
            }
            else
            {
                //Atribui
                if (pVez.habilidades.Count < 3)
                    pVez.habilidades.Add(sortedSkills[i]);
                //Substitui
                else
                {
                    habilidadeSelecionada = sortedSkills[i];
                    substituirHab = true;
                    CarregarHud(pVez);
                    return;
                }
            }
        }
        if (manager.getMultiplayer() && !vezP2)
        {
            pVez = manager.P2.getPersonagem();
            manager.getEventSystem().SetSelectedGameObject(firstButton);
            CarregarHud(pVez);
            vezP2 = true;
        }
        else
            Encerrar();
    }
    public void Encerrar()
    {
        playerData.LevelUpDisponivel--;
        inUpgrade = false;
        hudLevelUp.SetActive(false);
        manager.getEventSystem().sendNavigationEvents = false;
        hudInGame.SetActive(true);
        manager.movePlayer(true);
    }
}
