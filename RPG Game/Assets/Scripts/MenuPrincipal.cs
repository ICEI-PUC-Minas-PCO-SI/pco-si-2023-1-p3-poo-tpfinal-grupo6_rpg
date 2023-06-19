using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    EventSystem eventSystem;
    public int[] playerSelecionado = new int[2];
    public Sprite[] faces;
    public Image[] players;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        GameObject aux = FindObjectOfType<MenuPrincipal>().gameObject;
        if (aux != null && !aux.Equals(gameObject))
            Destroy(aux);
        
        eventSystem = FindObjectOfType<EventSystem>();
        playerSelecionado[0] = 0;
        playerSelecionado[1] = 0;
    }
    private void SetImage()
    {
        players[0].sprite = faces[playerSelecionado[0]];
        players[1].sprite = faces[playerSelecionado[1]];
    }
    public void Selecionar()
    {
        playerSelecionado[0] = 0;
        playerSelecionado[1] = 0;
    }
    public void StartGame()
    {
        if(playerSelecionado[0] != 0)
            SceneManager.LoadScene(1);
    }
    public void Creditos()
    {
            SceneManager.LoadScene(2);
    }
    public void Sair()
    {
        Application.Quit();
    }
    public void CallWindow(GameObject aux)
    {
        aux.SetActive(!aux.activeSelf);
    }
    public void SetButton(GameObject aux)
    {
        eventSystem.SetSelectedGameObject(aux);
    }
    public void SelecionarPlayer(int p)
    {
        if (playerSelecionado[0] == p)
        {
            if (playerSelecionado[1] != 0)
            {
                playerSelecionado[0] = playerSelecionado[1];
                playerSelecionado[1] = 0;
            }
            else
            {
                playerSelecionado[0] = 0;
            }
            SetImage();
            return;
        }
        else if (playerSelecionado[1] == p)
        {
            playerSelecionado[1] = 0;
            SetImage();
            return;
        }

        if (playerSelecionado[0] == 0)
            playerSelecionado[0] = p;
        else if (playerSelecionado[1] == 0)
            playerSelecionado[1] = p;
        SetImage();
    }
}
