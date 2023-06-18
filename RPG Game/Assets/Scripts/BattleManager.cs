using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public float velTempoAcao, velMoveAtk, tempoInimigoAtk;
    int turno, jogadorVez, inimigoIndex, habilidadeSelecionada, chanceFugir;
    PersonagemUnity[] p;
    List<InimigoUnity> inimigos;
    bool inBattle, turnoPlayer, turnoInimigo, selecaoInimigo;
    Manager manager;
    Vector2 posicaoInicial;

    //UI
    public Slider tempoAcao;
    public Button[] buttonsHabilidades;
    public TextMeshProUGUI atacarTxtDano, fugirTxt;
    bool submitPress;

    //Inimigo
    GameObject targetSelecionado;
    int targetSelecionadoIndex, xpTotal;
    bool podeSelecionar;

    //Jogador
    bool jogadorMove;
    PlayerData playerData;

    void Start()
    {
        targetSelecionadoIndex = -1;
        manager = GetComponent<Manager>();
        playerData = manager.PlayerData;
        targetSelecionado = (GameObject)Instantiate(Resources.Load("TargetSelecionado"), transform.position, Quaternion.identity);
    }
    private void Update()
    {
        if (!submitPress)
        {
            if (turnoPlayer && selecaoInimigo && !jogadorMove)
            {
                if (Input.GetButtonUp("Horizontal"))
                    podeSelecionar = true;
                if (podeSelecionar)
                {
                    if (Input.GetAxisRaw("Horizontal") > 0)
                    {
                        targetSelecionadoIndex++;
                        podeSelecionar = false;
                    }
                    else if (Input.GetAxisRaw("Horizontal") < 0)
                    {
                        targetSelecionadoIndex--;
                        podeSelecionar = false;
                    }

                    if (targetSelecionadoIndex >= inimigos.Count)
                        targetSelecionadoIndex = 0;
                    else if (targetSelecionadoIndex < 0)
                        targetSelecionadoIndex = inimigos.Count - 1;
                }

                if (Input.GetButtonDown("Cancel") && selecaoInimigo)
                {
                    selecaoInimigo = false;
                    manager.getEventSystem().SetSelectedGameObject(manager.firstButtonBattleStart);
                }
                if (Input.GetButtonDown("Submit") && !jogadorMove)
                {
                    selecaoInimigo = false;
                    podeSelecionar = true;
                    jogadorMove = true;
                }
            }
        }
        else
        {
            if (Input.GetButtonUp("Submit"))
                submitPress = false;
        }
    }
    void FixedUpdate()
    {
        targetSelecionado.SetActive(selecaoInimigo && turnoPlayer && !jogadorMove);

        if (inBattle)
        {
            if (inimigos.Count == 0)
            {
                EndBattle();
                return;
            }

            manager.getEventSystem().sendNavigationEvents = turnoPlayer && !selecaoInimigo && !jogadorMove;
            if (turnoPlayer && !jogadorMove)
            {
                tempoAcao.gameObject.SetActive(true);
                tempoAcao.value = Mathf.MoveTowards(tempoAcao.value, tempoAcao.maxValue, velTempoAcao * Time.deltaTime);
                if (tempoAcao.value == 1)
                    ProximoTurno();
            }
            else
            {
                tempoAcao.gameObject.SetActive(false);
            }

            if (turnoInimigo)
            {
                InimigoVez();
            }
            else if (turnoPlayer && selecaoInimigo && !jogadorMove)
            {
                if (Input.GetButtonUp("Horizontal"))
                    podeSelecionar = true;
                if (podeSelecionar)
                {
                    if (Input.GetAxisRaw("Horizontal") > 0)
                    {
                        targetSelecionadoIndex++;
                        podeSelecionar = false;
                    }
                    else if (Input.GetAxisRaw("Horizontal") < 0)
                    {
                        targetSelecionadoIndex--;
                        podeSelecionar = false;
                    }

                    if (targetSelecionadoIndex >= inimigos.Count)
                        targetSelecionadoIndex = 0;
                    else if (targetSelecionadoIndex < 0)
                        targetSelecionadoIndex = inimigos.Count - 1;
                }
                targetSelecionado.transform.position = inimigos[targetSelecionadoIndex].transform.position + new Vector3(0, 1);
            }
            if (jogadorMove)
            {
                PlayerVez();
            }
        }
    }
    public void Battle(List<InimigoUnity> inimigos, PersonagemUnity p1, PersonagemUnity p2)
    {
        if(p2 != null)
        {
            p = new PersonagemUnity[2];
            p[0] = p1;
            p[1] = p2;
        }
        else
        {
            p = new PersonagemUnity[1];
            p[0] = p1;
        }
        this.inimigos = inimigos;
        chanceFugir = 7;
        xpTotal = 0;
        inBattle = true;
        turno = -1;
        jogadorVez = 0;
        ProximoTurno();
    }
    private void ProximoTurno()
    {
        if (inBattle)
        {
            turno++;
            tempoAcao.value = 0;
            if (manager.getMultiplayer())
            {
                if (jogadorVez == 2)
                    TurnoInimigo();
                else
                    TurnoPlayer();
            }
            else
            {
                if (jogadorVez == 1)
                    TurnoInimigo();
                else
                    TurnoPlayer();
            }
        }
    }
    private void TurnoPlayer()
    {
        turnoPlayer = true;
        turnoInimigo = false;
        jogadorVez++; 
        HabilidadeController();
        posicaoInicial = p[jogadorVez - 1].transform.position;
        manager.SelecionarBotaoAtaque();
    }
    private void TurnoInimigo()
    {
        if (!turnoInimigo)
        {
            inimigoIndex = 0;
            turnoInimigo = true; 
            turnoPlayer = false;
            posicaoInicial = inimigos[inimigoIndex].transform.position;
            inimigos[inimigoIndex].Atacar(p);
        }
    }
    private void InimigoVez()
    {
        if (inimigos[inimigoIndex].getTarget() != null)
        {
            inimigos[inimigoIndex].transform.position = Vector2.MoveTowards(inimigos[inimigoIndex].transform.position,
                inimigos[inimigoIndex].getTarget().transform.position, velMoveAtk * Time.deltaTime);
            if (Vector2.Distance(inimigos[inimigoIndex].transform.position, inimigos[inimigoIndex].getTarget().transform.position) <= 1.6f)
            {
                StartCoroutine(DanoView(inimigos[inimigoIndex].getTarget().GetComponent<SpriteRenderer>()));
                inimigos[inimigoIndex].setTarget(null);
            }
        }
        else
        {
            inimigos[inimigoIndex].transform.position = Vector2.MoveTowards(inimigos[inimigoIndex].transform.position,
               posicaoInicial, velMoveAtk * Time.deltaTime);
            if (Vector2.Distance(inimigos[inimigoIndex].transform.position, posicaoInicial) <= 0.1f)
            {
                inimigoIndex++;
                if (inimigoIndex >= inimigos.Count)
                {
                    jogadorVez = 0;
                    turnoInimigo = false;
                    selecaoInimigo = false;
                    ProximoTurno();
                }
                else
                {
                    posicaoInicial = inimigos[inimigoIndex].transform.position;
                    inimigos[inimigoIndex].Atacar(p);
                }
            }
        }
    }
    private void PlayerVez()
    {   
        if (targetSelecionadoIndex != -1)
        {
            p[jogadorVez - 1].transform.position = Vector2.MoveTowards(p[jogadorVez - 1].transform.position,
                inimigos[targetSelecionadoIndex].transform.position, velMoveAtk * Time.deltaTime);
            if (Vector2.Distance(p[jogadorVez - 1].transform.position, inimigos[targetSelecionadoIndex].transform.position) <= 1.6f)
            {
                inimigos[targetSelecionadoIndex].getPersonagem().atributo.Hp -= p[jogadorVez - 1].getPersonagem().DarDano(habilidadeSelecionada);
                StartCoroutine(DanoView(inimigos[targetSelecionadoIndex].GetComponent<SpriteRenderer>()));
                targetSelecionadoIndex = -1;
            }
        }
        else
        {
            p[jogadorVez - 1].transform.position = Vector2.MoveTowards(p[jogadorVez - 1].transform.position,
               posicaoInicial, velMoveAtk * Time.deltaTime);
            if (Vector2.Distance(p[jogadorVez - 1].transform.position, posicaoInicial) <= 0.1f)
            {
                jogadorMove = false;
                ProximoTurno();
            }
        }
    }
    public void SelecaoInimigo(int hab)
    {
        if(hab >= 0 && p[jogadorVez-1].getPersonagem().atributo.Mana < 
            p[jogadorVez - 1].getPersonagem().habilidades[hab].Custo)
        {
            return;
        }
        habilidadeSelecionada = hab;
        targetSelecionadoIndex = 0;
        podeSelecionar = true;
        selecaoInimigo = true;
        submitPress = Input.GetButton("Submit");
    }
    IEnumerator DanoView(SpriteRenderer spriteView)
    {
        if (spriteView != null)
            spriteView.color = Color.red;
        yield return new WaitForSeconds(tempoInimigoAtk);
        if (spriteView != null)
            spriteView.color = Color.white;
    }
    private void EndBattle()
    {
        inBattle = false;
        bool inimigosMortos = inimigos.Count <= 0;
        if (inimigosMortos)
        {
            playerData.SetXp(xpTotal);
            foreach (PersonagemUnity p in p)
                p.setInBattle(false);
        }
        else
        {
            foreach (InimigoUnity i in inimigos)
                Destroy(i.gameObject);

            foreach (PersonagemUnity p in p)
                p.setInBattle(false);
        }
        manager.EndBattle(inimigosMortos);
    }
    public void inimigoMorto(InimigoUnity i) {
        xpTotal += i.getPersonagem().atributo.Xp; 
        inimigos.Remove(i);
    }
    public void Fugir()
    {
        if (Random.Range(0, 11) >= chanceFugir)
        {
            EndBattle();
        }
        else
        {
            jogadorVez = 2;
            ProximoTurno();
        }
    }
    private void HabilidadeController()
    {
        PersonagemJogador personagem = p[jogadorVez - 1].getPersonagem();
        atacarTxtDano.text = personagem.atributo.Atk.ToString();
        fugirTxt.text = (chanceFugir * 10).ToString();

        foreach (Button b in buttonsHabilidades)
            b.gameObject.SetActive(false);

        for(int i = 0; i < personagem.habilidades.Count; i++)
        {
            buttonsHabilidades[i].gameObject.SetActive(true);
            TextMeshProUGUI[] texts = buttonsHabilidades[i].GetComponentsInChildren<TextMeshProUGUI>();
            texts[0].text = personagem.habilidades[i].Nome;
            texts[1].text = ((int)(personagem.habilidades[i].Multiplicador * personagem.atributo.Atk * 1.6f)).ToString();
            texts[2].text = personagem.habilidades[i].Custo.ToString();
        }
    }
    public bool InBattle { get => inBattle; set => inBattle = value; }

}
