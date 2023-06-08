using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventarioManager : MonoBehaviour
{
    //Geral
    public GameObject hudInventario,hudInGame, firstButton;
    EventSystem eventSystem;
    public Sprite[] iconeItens;
    public List<ItemObjeto> listaItens = new List<ItemObjeto>();

    //Itens
    public Image[] localItens, itensP1, itensP2;
    public Image itemView;
    public TextMeshProUGUI desc;
    public Button equipar, desequipar, descartar;

    //Player
    public List<ItemObjeto> mochilaPlayer = new List<ItemObjeto>();
    PlayerMove player;

    private void Awake()
    {
        eventSystem = FindObjectOfType<EventSystem>();
        ConstruirItens();
        mochilaPlayer.Add(listaItens[1]);
        mochilaPlayer.Add(listaItens[3]);
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            if (player == null)
                player = FindObjectOfType<PlayerMove>();
            if (!hudInventario.activeSelf)
                AbrirInventario();
            else
                FecharInventario();
        }
    }
    public void ItemSelecionado(int pos)
    {
        if(pos >= 12)
        {
            desequipar.gameObject.SetActive(true);
            equipar.gameObject.SetActive(false);
        }
        else
        {
            desequipar.gameObject.SetActive(false);
            equipar.gameObject.SetActive(true);
        }
        itemView.sprite = mochilaPlayer[pos].Img;
        desc.text = mochilaPlayer[pos].Desc;
    }
    public void Equipar()
    {

    }
    public void Desequipar()
    {

    }
    public void Descartar()
    {

    }
    public void AbrirInventario()
    {
        CarregarItensHUD();
        hudInGame.SetActive(false);
        hudInventario.SetActive(true);
        eventSystem.SetSelectedGameObject(firstButton);
        eventSystem.sendNavigationEvents = true;
        player.enabled = false;
    }
    public void FecharInventario()
    {
        hudInGame.SetActive(true);
        hudInventario.SetActive(false);
        eventSystem.sendNavigationEvents = false;
        player.enabled = true;
    }
    void CarregarItensHUD()
    {
        for(int i = 0; i < localItens.Length; i++)
        {
            if (i < mochilaPlayer.Count)
            {
                localItens[i].sprite = mochilaPlayer[i].Img;
                localItens[i].gameObject.SetActive(true);
            }
            else
            {
                localItens[i].enabled = false;
                localItens[i].gameObject.SetActive(false);
            }
        }
    }
    public void ConstruirItens()
    {
        int i = 0;
        listaItens.Add(new ItemObjeto("Poção de cura: Cura a vida em +20", 20, iconeItens[i++]));
        listaItens.Add(new ItemObjeto("Poção de cura maior: Cura a vida em +50", 50, iconeItens[i++]));
        listaItens.Add(new ItemObjeto("Poção de mana: Recupera mana em +30", 30, iconeItens[i++]));
        listaItens.Add(new ItemObjeto("Poção de fortalecimento: aumenta o ataque em +10", 10, iconeItens[i++]));
    }
}
