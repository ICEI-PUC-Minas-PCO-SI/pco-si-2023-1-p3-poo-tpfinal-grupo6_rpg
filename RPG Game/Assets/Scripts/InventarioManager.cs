using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventarioManager : MonoBehaviour
{
    //Geral
    public GameObject hudInventario,hudInGame, firstButton, selecionarPlayerHUD, infoViewHUD;
    public Button[] playerSelecionarButton;
    EventSystem eventSystem;
    public Sprite[] iconeItens;
    Manager manager;
    BattleManager battleManager;

    //Itens
    public Image[] localItens;
    public Image itemView, armaP1, armaP2;
    public Image faceP1, faceP2;
    public TextMeshProUGUI desc;
    public Button equipar, voltarInfoView;

    //Player
    PersonagemUnity[] p;
    public ItemObjeto itemSelecionado;
    public GameObject viewItemP2;
    PlayerData playerData;

    private void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();
        viewItemP2.SetActive(false);
        battleManager = GetComponent<BattleManager>();
        manager = GetComponent<Manager>();
        p = manager.getPersonagensUnity();
        playerSelecionarButton[1].interactable = manager.getMultiplayer();
        eventSystem = FindObjectOfType<EventSystem>();
    }
    void Update()
    {
        if (!battleManager.InBattle && Input.GetKeyDown("m"))
        {
            if (!hudInventario.activeSelf)
                AbrirInventario();
            else
                FecharInventario();         
        }
    }
    public void ItemSelecionado(int pos)
    {
        itemSelecionado = playerData.Mochila[pos];
        itemView.sprite = itemSelecionado.Img;
        desc.text = itemSelecionado.Desc;
        if (itemSelecionado.arma)
            equipar.GetComponentInChildren<TextMeshProUGUI>().text = itemSelecionado.Personagem != null ? "Desequipar" : "Equipar";
        else
            equipar.GetComponentInChildren<TextMeshProUGUI>().text = "Usar";
        eventSystem.SetSelectedGameObject(voltarInfoView.gameObject);
        infoViewHUD.SetActive(true);
    }
    public void HUDPersonagem()
    {
        if (itemSelecionado.Personagem != null)
        {
            itemSelecionado.Personagem.Arma = null;
            itemSelecionado.Personagem = null;
            SelecionarInventario();
            return;
        }
        selecionarPlayerHUD.SetActive(true);         
            eventSystem.SetSelectedGameObject(playerSelecionarButton[0].gameObject);
    }
    public void Descartar()
    {
        playerData.Mochila.Remove(itemSelecionado);
        if (itemSelecionado.Personagem != null)
            itemSelecionado.Personagem.Arma = null;
        itemSelecionado = null;
        CarregarItensHUD();
        SelecionarInventario();
    }
    public void AbrirInventario()
    {
        faceP1.sprite = manager.faceP1.sprite;
        if (manager.getMultiplayer())
        {
            viewItemP2.SetActive(true);
            faceP2.sprite = manager.faceP2.sprite;
        }
        CarregarItensHUD();
        selecionarPlayerHUD.SetActive(false);
        infoViewHUD.SetActive(false);
        hudInGame.SetActive(false);
        hudInventario.SetActive(true);
        SelecionarInventario();
        eventSystem.sendNavigationEvents = true;
        manager.movePlayer(false);
    }
    public void FecharInventario()
    {
        hudInGame.SetActive(true);
        hudInventario.SetActive(false);
        eventSystem.sendNavigationEvents = false;
        manager.movePlayer(true);
    }
    void CarregarItensHUD()
    {
        for(int i = 0; i < localItens.Length; i++)
        {
            if (i < playerData.Mochila.Count)
            {
                localItens[i].sprite = playerData.Mochila[i].Img;
                if (playerData.Mochila[i].Personagem != null)
                    localItens[i].color = new Color(255, 255, 255, 125);
                else
                    localItens[i].color = new Color(255, 255, 255, 255);
                localItens[i].gameObject.SetActive(true);
            }
            else
            {
                localItens[i].gameObject.SetActive(false);
            }
        }
        if (p[0].Arma != null)
        {
            armaP1.sprite = p[0].Arma.Img;
            armaP1.gameObject.SetActive(true);
        }
        else
            armaP1.gameObject.SetActive(false);

        if (manager.getMultiplayer())
        {
            if (p[1].Arma != null)
            {
                armaP2.sprite = p[1].Arma.Img;
                armaP2.gameObject.SetActive(true);
            }
            else
                armaP2.gameObject.SetActive(false);
        }
    }
    public void SelecionarInventario()
    {
        CarregarItensHUD();
        selecionarPlayerHUD.SetActive(false);
        infoViewHUD.SetActive(false);
        eventSystem.SetSelectedGameObject(firstButton);
    }
    public void SelecionarPlayerItem(int playerSelecionado)
    {
        if (itemSelecionado.Arma)
        {
            p[playerSelecionado].Arma = itemSelecionado;
            itemSelecionado.Personagem = p[playerSelecionado];
        }
        else
        {
            p[playerSelecionado].getPersonagem().UsarItem(itemSelecionado);
            Descartar();
        }
        CarregarItensHUD();
        SelecionarInventario();
    }
}
