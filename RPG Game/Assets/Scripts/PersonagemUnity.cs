using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PersonagemUnity : MonoBehaviour
{
    public int classe;
    public Sprite img;
    private PersonagemJogador personagem;

    //UI
    public Slider vidaSlider, levelSlider;
    public TextMeshProUGUI vidaTxt, levelTxt;
    public Image face;

    void Start()
    {
        if (classe == 0)
        {
            personagem = new Guerreiro("Guerreiro");
        }
        else if (classe == 1)
        {
            personagem = new Mago("Mago");
        }
        else if (classe == 2)
        {
            personagem = new Ninja("Ninja");
        }
        face.sprite = img;
    }
    private void Update()
    {
        vidaSlider.value = personagem.atributo.Hp;
        vidaSlider.maxValue = personagem.atributo.MaxHp;
        vidaTxt.text = (vidaSlider.value + "/" + vidaSlider.maxValue);
        levelSlider.value = personagem.atributo.Xp;
        levelTxt.text = personagem.atributo.Nivel.ToString();
    }
    public PersonagemJogador getPersonagem() { return personagem; }
}
