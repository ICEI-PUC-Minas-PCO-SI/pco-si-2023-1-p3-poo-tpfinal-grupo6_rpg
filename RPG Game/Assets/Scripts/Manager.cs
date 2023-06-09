using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Manager : MonoBehaviour
{
    //Outros
    public bool multiplayer;
    public int p1Classe, p2Classe;
    bool inBattle;

    public GameObject hudPlayer2, hudBattle;
    EventSystem eventSystem;
    public GameObject firstButtonBattleStart;

    //Cam
    PixelPerfectCamera camConfig;
    public Vector2 camSize;
    CamMove cam;
    public float distanceCamera, cameraHeight;

    //Local Combate
    PlayerMove playerMove;
    PlayerFollow playerFollow;
    InimigoMove inimigo;
    Vector2 playerPosition;

    //Modo Combate
    public Transform localSpawn;
    BattleManager battleManager;
    public List<InimigoUnity> inimigosCombate;

    //UI
    public Slider vidaSliderP1, levelSliderP1, manaSliderP1;
    public TextMeshProUGUI vidaTxtP1, levelTxtP1, manaTxtP1;
    public Image faceP1;

    public Slider vidaSliderP2, levelSliderP2, manaSliderP2;
    public TextMeshProUGUI vidaTxtP2, levelTxtP2, manaTxtP2;
    public Image faceP2;
    public Sprite[] faces;
    
    //Players
    PersonagemUnity p1, p2;

    void Awake()
    {
        battleManager = GetComponent<BattleManager>();
        hudBattle.SetActive(false);
        eventSystem = FindObjectOfType<EventSystem>();
        camConfig = FindObjectOfType<PixelPerfectCamera>();
        camConfig.assetsPPU = (int)camSize.x;
        camConfig.refResolutionX = Screen.width;
        camConfig.refResolutionY = Screen.height;
        foreach(CanvasScaler aux in FindObjectsOfType<CanvasScaler>())
        {
            aux.referenceResolution = new Vector2(Screen.width, Screen.height);
        }
        ComecarJogo(localSpawn.position);
        faceP1.sprite = faces[p1Classe];
        if (p2 != null)
            faceP2.sprite = faces[p2Classe];
    }
    private void Update()
    {
        vidaSliderP1.value = p1.getPersonagem().atributo.Hp;
        vidaSliderP1.maxValue = p1.getPersonagem().atributo.MaxHp;
        vidaTxtP1.text = (vidaSliderP1.value + "/" + vidaSliderP1.maxValue);
        manaSliderP1.value = p1.getPersonagem().atributo.Mana;
        manaSliderP1.maxValue = p1.getPersonagem().atributo.MaxMana;
        manaTxtP1.text = (manaSliderP1.value + "/" + manaSliderP1.maxValue);
        levelSliderP1.value = p1.getPersonagem().atributo.Xp;
        levelSliderP1.maxValue = p1.getPersonagem().atributo.MaxXp;
        levelTxtP1.text = p1.getPersonagem().atributo.Nivel.ToString();
        if (p2 != null)
        {
            vidaSliderP2.value = p2.getPersonagem().atributo.Hp;
            vidaSliderP2.maxValue = p2.getPersonagem().atributo.MaxHp;
            vidaTxtP2.text = (vidaSliderP2.value + "/" + vidaSliderP2.maxValue);
            manaSliderP2.value = p2.getPersonagem().atributo.Mana;
            manaSliderP2.maxValue = p2.getPersonagem().atributo.MaxMana;
            manaTxtP2.text = (manaSliderP2.value + "/" + manaSliderP2.maxValue);
            levelSliderP2.value = p2.getPersonagem().atributo.Xp;
            levelSliderP2.maxValue = p2.getPersonagem().atributo.MaxXp;
            levelTxtP2.text = p2.getPersonagem().atributo.Nivel.ToString();
        }
    }
    public void StartBattle()
    {
        if (!inBattle)
        {
            eventSystem.sendNavigationEvents = true;
            SelecionarBotaoAtaque();
            hudBattle.SetActive(true);

            //Cam
            camConfig.assetsPPU = (int)camSize.y;
            cam.enabled = false;

            //Player
            playerPosition = playerMove.transform.position;
            playerMove.enabled = false;
            playerMove.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            //Posi��o em BattleMode
            //Jogadores
            if (multiplayer)
            {
                playerFollow.enabled = false;
                playerMove.transform.position = (Vector2)cam.transform.position - new Vector2(distanceCamera, -1.3f);
                playerFollow.transform.position = (Vector2)cam.transform.position - new Vector2(distanceCamera, 1.3f);
            }
            else
            {
                playerMove.transform.position = (Vector2)cam.transform.position - new Vector2(distanceCamera, 0);
            }

            CriarInimigosCombate();

            //Ajuste Cam
            cam.transform.position -= new Vector3(0, cameraHeight, 0);

            //Modo Combate
            PersonagemUnity p1 = playerMove.GetComponent<PersonagemUnity>();
            p1.setInBattle(true);
            PersonagemUnity p2 = null;
            if (playerFollow != null)
            {
                p2 = playerFollow.GetComponent<PersonagemUnity>();
                p2.setInBattle(true);
            }

            foreach (InimigoUnity i in inimigosCombate)
                i.vida.gameObject.SetActive(true);

            battleManager.Battle(inimigosCombate, p1, p2);
        }
    }
    public void EndBattle(bool inimigoMorto)
    {
        hudBattle.SetActive(false);
        eventSystem.sendNavigationEvents = false;
        //Cam
        camConfig.assetsPPU = (int)camSize.x;
        cam.enabled = true;
        //Player
        playerMove.transform.position = playerPosition;
        playerMove.enabled = true;
        if(multiplayer)
            playerFollow.enabled = true;
        //Inimigo
        if (!inimigoMorto)
        {
            inimigo.resetPosition();
            inimigo.setInBattle(false);
            inimigo.gameObject.SetActive(true);
        }
        else
        {
            Destroy(inimigo);
        }
        inBattle = false;
    }
    private void CriarPersonagem(Vector2 localSpawn, bool principal, int classe)
    {
        GameObject player = (GameObject)Instantiate((GameObject)Resources.Load("PersonagemUnity"), localSpawn, Quaternion.identity);   
        player.transform.position = localSpawn;
        if (principal)
        {
            player.AddComponent<PlayerMove>();
            player.GetComponent<SpriteRenderer>().sortingOrder = 1;
            playerMove = player.GetComponent<PlayerMove>();
            p1 = player.GetComponent<PersonagemUnity>();
            p1.classe = classe;
        }
        else
        {
            Destroy(player.GetComponent<BoxCollider2D>());
            player.AddComponent<PlayerFollow>();
            playerFollow = player.GetComponent<PlayerFollow>();
            p2 = player.GetComponent<PersonagemUnity>();
            p2.classe = classe;
        }     
    }
    private void CriarInimigosCombate()
    {
        inBattle = true;
        GameObject copia = (GameObject)Instantiate(inimigo.gameObject, inimigo.transform.position, Quaternion.identity);
        Destroy(copia.GetComponent<InimigoMove>());
        Destroy(copia.GetComponent<CircleCollider2D>());
        Destroy(copia.GetComponent<Rigidbody2D>());
        inimigo.gameObject.SetActive(false);
        
        inimigosCombate = new List<InimigoUnity>();
        inimigosCombate.Add(copia.GetComponent<InimigoUnity>());

        int quantI = inimigo.GetComponent<InimigoUnity>().getQuantidadeExtra();
        if (quantI == 0)
        {
            inimigosCombate[0].transform.position = (Vector2)cam.transform.position + new Vector2(distanceCamera, 0);
        }
        else if (quantI == 1)
        {
            //Cria
            GameObject aux = (GameObject)Instantiate(copia, transform.position, Quaternion.identity);
            inimigosCombate.Add(aux.GetComponent<InimigoUnity>());

            //Posiciona
            inimigosCombate[0].transform.position = (Vector2)cam.transform.position + new Vector2(distanceCamera, -1.3f);
            inimigosCombate[1].transform.position = (Vector2)cam.transform.position + new Vector2(distanceCamera, 1.3f);
        }
        else if (quantI == 2)
        {
            //Cria
            GameObject aux = (GameObject)Instantiate(copia, transform.position, Quaternion.identity);
            inimigosCombate.Add(aux.GetComponent<InimigoUnity>());
            aux = (GameObject)Instantiate(copia, transform.position, Quaternion.identity);
            inimigosCombate.Add(aux.GetComponent<InimigoUnity>());

            //Posiciona
            inimigosCombate[0].transform.position = (Vector2)cam.transform.position + new Vector2(distanceCamera, -1.3f);
            inimigosCombate[1].transform.position = (Vector2)cam.transform.position + new Vector2(distanceCamera + 1.8f, 0);
            inimigosCombate[2].transform.position = (Vector2)cam.transform.position + new Vector2(distanceCamera, 1.3f);
        }
        else if(quantI == 3)
        {
            //Cria
            GameObject aux = (GameObject)Instantiate(copia, transform.position, Quaternion.identity);
            inimigosCombate.Add(aux.GetComponent<InimigoUnity>());
            aux = (GameObject)Instantiate(copia, transform.position, Quaternion.identity);
            inimigosCombate.Add(aux.GetComponent<InimigoUnity>());
            aux = (GameObject)Instantiate(copia, transform.position, Quaternion.identity);
            inimigosCombate.Add(aux.GetComponent<InimigoUnity>());

            //Posiciona
            inimigosCombate[0].transform.position = (Vector2)cam.transform.position + new Vector2(distanceCamera, -1.3f);
            inimigosCombate[1].transform.position = (Vector2)cam.transform.position + new Vector2(distanceCamera + 1.8f, -1.5f);
            inimigosCombate[2].transform.position = (Vector2)cam.transform.position + new Vector2(distanceCamera + 1.8f, 1.5f);
            inimigosCombate[3].transform.position = (Vector2)cam.transform.position + new Vector2(distanceCamera, 1.3f);
        }
    }
    private void ComecarJogo(Vector2 localSpawn)
    {
        cam = FindObjectOfType<CamMove>();
        CriarPersonagem(localSpawn, true, p1Classe);
        if (multiplayer)
        {
            CriarPersonagem(localSpawn, false, p2Classe);
            hudPlayer2.SetActive(true);
        }
        else
        {
            hudPlayer2.SetActive(false);
        }

    }
    public void setInimigo(InimigoMove inimigo) { this.inimigo = inimigo; }
    public EventSystem getEventSystem() { return eventSystem; }
    public bool getMultiplayer() { return multiplayer; }
    public void SelecionarBotaoAtaque()
    {
        eventSystem.SetSelectedGameObject(firstButtonBattleStart);
    }
    public PersonagemUnity[] getPersonagensUnity()
    {
        PersonagemUnity[] players = new PersonagemUnity[p2 != null ? 2 : 1];
        players[0] = p1;
        if (p2 != null)
            players[1] = p2;
        return players;
    }
}
