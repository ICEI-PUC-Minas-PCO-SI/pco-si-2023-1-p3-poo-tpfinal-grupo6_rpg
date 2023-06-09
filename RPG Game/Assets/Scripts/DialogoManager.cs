using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogoManager : MonoBehaviour
{
    public GameObject hudDialogo;
    public Image face;
    public TextMeshProUGUI texto, nome;
    public string[] dialogo;
    public int linhaAtual;
    Manager manager;

    void Start()
    {
        manager = GetComponent<Manager>();
    }

    void Update()
    {
        if (hudDialogo.activeSelf)
        {
            if (Input.GetButtonDown("Submit"))
            {
                if (linhaAtual >= dialogo.Length)
                {
                    Encerrar();
                    return;
                }
                texto.text = dialogo[linhaAtual];
                linhaAtual++;
            }
        }
    }
    public void ComecarConversa(Sprite face, string[] dialogo, string nome)
    {
        this.face.sprite = face;
        this.dialogo = dialogo;
        this.nome.text = nome;
        manager.movePlayer(false);
        hudDialogo.SetActive(true);
        linhaAtual = 0;
    }
    public void Encerrar()
    {
        manager.movePlayer(true);
        hudDialogo.SetActive(false);
    }
}
