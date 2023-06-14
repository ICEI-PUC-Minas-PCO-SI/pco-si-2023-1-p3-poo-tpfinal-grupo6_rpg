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
    BattleManager battleManager;

    //Itens
    public Image[] localItens;
    public Image itemView, armaP1, armaP2;
    public Image faceP1, faceP2;
    public TextMeshProUGUI desc;
    public Button equipar, voltarInfoView;

    //Player
    public List<ItemObjeto> mochilaPlayer = new List<ItemObjeto>();
    PersonagemUnity[] p;
    public ItemObjeto itemSelecionado;
    public GameObject viewItemP2;

    private void Awake()
    {
        viewItemP2.SetActive(false);
        battleManager = GetComponent<BattleManager>();
        manager = GetComponent<Manager>();
        p = manager.getPersonagensUnity();
        playerSelecionarButton[1].interactable = manager.getMultiplayer();
        eventSystem = FindObjectOfType<EventSystem>();
        ConstruirItens();
        mochilaPlayer.Add(listaItens[0]);
        mochilaPlayer.Add(listaItens[4]);
        mochilaPlayer.Add(listaItens[2]);
    }
    void Update()
    {
        if (!battleManager.InBattle && Input.GetKeyDown("i"))
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
        if (itemSelecionado.Personagem)
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
        mochilaPlayer.Remove(itemSelecionado);
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
        CarregarItensHUD();
        selecionarPlayerHUD.SetActive(false);
        infoViewHUD.SetActive(false);
        eventSystem.SetSelectedGameObject(firstButton);
    }
    public void SelecionarPlayerItem(int playerSelecionado)
    {
        //Equipar arma
        if (itemSelecionado.Personagem == null)
        {
            if (itemSelecionado.Arma)
            {
                p[playerSelecionado].Arma = itemSelecionado;
                itemSelecionado.Personagem = p[playerSelecionado];
            }
            else
            {
                p[playerSelecionado].getPersonagem().atributo.Hp += itemSelecionado.Valor;
                Descartar();
            }
            
        }
        //Desequipar
        else
        {
            
        }
        CarregarItensHUD();
        SelecionarInventario();
    }
}
