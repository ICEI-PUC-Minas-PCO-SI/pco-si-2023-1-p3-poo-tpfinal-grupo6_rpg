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
    public List<ItemObjeto> listaItens = new List<ItemObjeto>();
    Manager manager;

    //Itens
    public Image[] localItens, itensP1, itensP2;
    public Image itemView;
    public TextMeshProUGUI desc;
    public Button equipar, voltarInfoView;

    //Player
    public List<ItemObjeto> mochilaPlayer = new List<ItemObjeto>();
    PersonagemUnity[] p;
    ItemObjeto itemSelecionado;

    private void Awake()
    {
        manager = GetComponent<Manager>();
        p = manager.getPersonagensUnity();
        playerSelecionarButton[1].interactable = manager.multiplayer;
        eventSystem = FindObjectOfType<EventSystem>();
        ConstruirItens();
        mochilaPlayer.Add(listaItens[1]);
        mochilaPlayer.Add(listaItens[3]);
    }
    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            if (!hudInventario.activeSelf)
                AbrirInventario();
            else
                FecharInventario();
        }
    }
    public void ItemSelecionado(int pos)
    {
        itemSelecionado = mochilaPlayer[pos];
        itemView.sprite = itemSelecionado.Img;
        desc.text = itemSelecionado.Desc;
        equipar.GetComponentInChildren<TextMeshProUGUI>().text = itemSelecionado.Personagem != null ? "Desequipar" : "Equipar";
        eventSystem.SetSelectedGameObject(voltarInfoView.gameObject);
        infoViewHUD.SetActive(true);
    }
    public void HUDPersonagem()
    {
        if (itemSelecionado.Personagem == null)
        {
            if (itemSelecionado.Arma)
                if (p[0].Arma != null)
                    playerSelecionarButton[0].interactable = false;
                else
                    playerSelecionarButton[0].interactable = true;
            else
                if (p[0].Inventario.Count > 3)
                playerSelecionarButton[0].interactable = false;
            else
                playerSelecionarButton[0].interactable = true;
            if (manager.getMultiplayer())
            {
                if (itemSelecionado.Arma)
                    if (p[1].Arma != null)
                        playerSelecionarButton[1].interactable = false;
                    else
                        playerSelecionarButton[1].interactable = true;
                else
                if (p[1].Inventario.Count > 3)
                    playerSelecionarButton[1].interactable = false;
                else
                    playerSelecionarButton[1].interactable = true;
            }
            selecionarPlayerHUD.SetActive(true);         
            eventSystem.SetSelectedGameObject(playerSelecionarButton[0].gameObject);
        }
        else
        {
            selecionarPlayerHUD.SetActive(true);
            eventSystem.SetSelectedGameObject(playerSelecionarButton[0].gameObject);
        }
    }
    public void Descartar()
    {
        mochilaPlayer.Remove(itemSelecionado);
        itemSelecionado = null;
    }
    public void AbrirInventario()
    {
        CarregarItensHUD();
        selecionarPlayerHUD.SetActive(false);
        infoViewHUD.SetActive(false);
        hudInGame.SetActive(false);
        hudInventario.SetActive(true);
        SelecionarInventario();
        eventSystem.sendNavigationEvents = true;
        p[0].GetComponent<PlayerMove>().enabled = false;
    }
    public void FecharInventario()
    {
        hudInGame.SetActive(true);
        hudInventario.SetActive(false);
        eventSystem.sendNavigationEvents = false;
        p[0].GetComponent<PlayerMove>().enabled = true;
    }
    void CarregarItensHUD()
    {
        for(int i = 0; i < localItens.Length; i++)
        {
            if (i < mochilaPlayer.Count)
            {
                localItens[i].sprite = mochilaPlayer[i].Img;
                if (mochilaPlayer[i].Personagem != null)
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
    }
    public void ConstruirItens()
    {
        int i = 0;
        listaItens.Add(new ItemObjeto("Poção de cura: Cura a vida em +20", 20, iconeItens[i++], false));
        listaItens.Add(new ItemObjeto("Poção de cura maior: Cura a vida em +50", 50, iconeItens[i++], false));
        listaItens.Add(new ItemObjeto("Poção de mana: Recupera mana em +30", 30, iconeItens[i++], false));
        listaItens.Add(new ItemObjeto("Poção de fortalecimento: aumenta o ataque em +10", 10, iconeItens[i++], false));
        listaItens.Add(new ItemObjeto("Cajado: aumenta o dano em +12", 12, iconeItens[i++], true));
    }
    public void SelecionarInventario()
    {
        selecionarPlayerHUD.SetActive(false);
        infoViewHUD.SetActive(false);
        eventSystem.SetSelectedGameObject(firstButton);
    }
    public void SelecionarPlayerItem(int playerSelecionado)
    {
        //Equipar
        if (itemSelecionado.Personagem == null)
        {
            if (itemSelecionado.Arma)
                p[playerSelecionado].Arma = itemSelecionado;
            else
                p[playerSelecionado].Inventario.Add(itemSelecionado);
            itemSelecionado.Personagem = p[playerSelecionado];
        }
        //Desequipar
        else
        {
            if (itemSelecionado.Arma)
                p[playerSelecionado].Arma = null;
            else
                p[playerSelecionado].Inventario.Remove(itemSelecionado);
            itemSelecionado.Personagem = null;
        }
        foreach (ItemObjeto i in p[0].Inventario)
            print(i.Desc);

        CarregarItensHUD();
        SelecionarInventario();
    }
}
