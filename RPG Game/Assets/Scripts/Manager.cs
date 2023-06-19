using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using RpgGame.models;

public class Manager : MonoBehaviour
{
    //Outros
    bool multiplayer;
    int p1Classe, p2Classe;
    bool inBattle;
    InventarioManager inventarioManager;


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
    public Animator animLevelUp;
    public Slider levelSlider;
    public TextMeshProUGUI levelTxt;

    public Slider vidaSliderP1, manaSliderP1;
    public TextMeshProUGUI vidaTxtP1, manaTxtP1;
    public Image faceP1;

    public Slider vidaSliderP2, manaSliderP2;
    public TextMeshProUGUI vidaTxtP2, manaTxtP2;
    public Image faceP2;
    public Sprite[] faces;
    
    //Players
    PersonagemUnity p1, p2;
    PlayerData playerData;

    public GameObject inimigosBoss;

    void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();
        p1Classe = playerData.PlayerSelecionado[0] - 1;
        if (playerData.PlayerSelecionado[1] != 0)
        {
            p2Classe = playerData.PlayerSelecionado[1] - 1;
            multiplayer = true;
        }
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
        inventarioManager = GetComponent<InventarioManager>();
        
    }
    private void Update()
    {
        animLevelUp.SetBool("LevelUpDisponivel", playerData.LevelUpDisponivel > 0);
        levelSlider.maxValue = playerData.XpMax;
        levelSlider.value = playerData.Xp;
        levelTxt.gameObject.SetActive(playerData.LevelUpDisponivel > 0);

        vidaSliderP1.value = p1.getPersonagem().atributo.Hp;
        vidaSliderP1.maxValue = p1.getPersonagem().atributo.MaxHp;
        vidaTxtP1.text = (vidaSliderP1.value + "/" + vidaSliderP1.maxValue);
        manaSliderP1.value = p1.getPersonagem().atributo.Mana;
        manaSliderP1.maxValue = p1.getPersonagem().atributo.MaxMana;
        manaTxtP1.text = (manaSliderP1.value + "/" + manaSliderP1.maxValue);
        if (p2 != null)
        {
            vidaSliderP2.value = p2.getPersonagem().atributo.Hp;
            vidaSliderP2.maxValue = p2.getPersonagem().atributo.MaxHp;
            vidaTxtP2.text = (vidaSliderP2.value + "/" + vidaSliderP2.maxValue);
            manaSliderP2.value = p2.getPersonagem().atributo.Mana;
            manaSliderP2.maxValue = p2.getPersonagem().atributo.MaxMana;
            manaTxtP2.text = (manaSliderP2.value + "/" + manaSliderP2.maxValue);
        }
    }
    public void StartBattle()
    {
        if (!inBattle)
        {
            eventSystem.sendNavigationEvents = true;
            SelecionarBotaoAtaque();
            inventarioManager.FecharInventario();
            hudBattle.SetActive(true);

            //Cam
            camConfig.assetsPPU = (int)camSize.y;
            cam.enabled = false;

            //Player
            playerPosition = playerMove.transform.position;
            movePlayer(false);

            //Posição em BattleMode
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

            battleManager.Battle(inimigosCombate, p1, p2, inimigo.boss);
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
        movePlayer(true);
        if (multiplayer)
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
    
        if (inimigo.boss)
        {
            GameObject aux = (GameObject)Instantiate(inimigosBoss, transform.position, Quaternion.identity);
            inimigosCombate.Add(aux.GetComponent<InimigoUnity>());
            aux = (GameObject)Instantiate(inimigosBoss, transform.position, Quaternion.identity);
            inimigosCombate.Add(aux.GetComponent<InimigoUnity>());

            //Posiciona
            inimigosCombate[0].transform.position = (Vector2)cam.transform.position + new Vector2(distanceCamera, -1.3f);
            inimigosCombate[1].transform.position = (Vector2)cam.transform.position + new Vector2(distanceCamera + 1.8f, 0);
            inimigosCombate[2].transform.position = (Vector2)cam.transform.position + new Vector2(distanceCamera, 1.3f);
            return;
        }

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
    public PlayerData PlayerData { get => playerData; set => playerData = value; }
    public PersonagemUnity P1 { get => p1; set => p1 = value; }
    public PersonagemUnity P2 { get => p2; set => p2 = value; }
    public void movePlayer(bool ativo)
    {
        playerMove.enabled = ativo;
        playerMove.GetComponent<BoxCollider2D>().isTrigger = !ativo;
        playerMove.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
