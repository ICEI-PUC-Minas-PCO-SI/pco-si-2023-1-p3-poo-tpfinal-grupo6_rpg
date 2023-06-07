using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public float velTempoAcao, velMoveAtk, tempoInimigoAtk;
    int turno, jogadorVez, inimigoIndex;
    PersonagemUnity[] p;
    List<InimigoUnity> inimigos;
    bool inBattle, turnoPlayer, turnoInimigo, selecaoInimigo;
    Manager manager;
    Vector2 posicaoInicial;

    //UI
    public Slider tempoAcao;

    //Inimigo
    GameObject targetSelecionado;
    int targetSelecionadoIndex;
    bool podeSelecionar;

    //Jogador
    bool jogadorMove;

    void Start()
    {
        targetSelecionadoIndex = -1;
        manager = GetComponent<Manager>();
        targetSelecionado = (GameObject)Instantiate(Resources.Load("TargetSelecionado"), transform.position, Quaternion.identity);
    }

    void FixedUpdate()
    {
        targetSelecionado.SetActive(selecaoInimigo && turnoPlayer && !jogadorMove);

        if (inBattle)
        {
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

                if (Input.GetButtonDown("Cancel"))
                {
                    selecaoInimigo = false;
                    manager.getEventSystem().SetSelectedGameObject(manager.firstButtonBattleStart);
                }
                if (Input.GetButtonDown("Submit"))
                {
                    selecaoInimigo = false;
                    podeSelecionar = true;
                    jogadorMove = true;
                }
            }
            if (jogadorMove)
            {
                PlayerVez();
            }
        }
    }
    public void Battle(List<InimigoUnity> inimigos)
    {
        if (p == null)
            p = FindObjectsOfType<PersonagemUnity>();
        this.inimigos = inimigos;
        inBattle = true;
        turno = -1;
        jogadorVez = 0;
        ProximoTurno();
    }
    public void ProximoTurno()
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
    public void TurnoPlayer()
    {
        if (!turnoPlayer)
        {
            turnoPlayer = true;
            turnoInimigo = false;
            jogadorVez++;
            posicaoInicial = p[jogadorVez - 1].transform.position;
        }
    }
    public void TurnoInimigo()
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
    public void InimigoVez()
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
    public void PlayerVez()
    {   
        if (targetSelecionadoIndex != -1)
        {
            p[jogadorVez - 1].transform.position = Vector2.MoveTowards(p[jogadorVez - 1].transform.position,
                inimigos[targetSelecionadoIndex].transform.position, velMoveAtk * Time.deltaTime);
            if (Vector2.Distance(p[jogadorVez - 1].transform.position, inimigos[targetSelecionadoIndex].transform.position) <= 1.6f)
            {
                inimigos[targetSelecionadoIndex].getPersonagem().atributo.Hp -= p[jogadorVez - 1].getPersonagem().atributo.Atk;
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
    public void SelecaoInimigo(int idAtk)
    {
        targetSelecionadoIndex = 0;
        podeSelecionar = true;
        selecaoInimigo = true;
    }
    IEnumerator DanoView(SpriteRenderer spriteView)
    {
        spriteView.color = Color.red;
        yield return new WaitForSeconds(tempoInimigoAtk);
        spriteView.color = Color.white;
    }
}
