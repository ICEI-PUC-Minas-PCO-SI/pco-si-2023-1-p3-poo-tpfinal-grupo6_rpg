using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using TMPro;

public class Manager : MonoBehaviour
{
    //Outros
    public bool multiplayer;
    public string p1, p2;
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
    public Slider vidaSliderP1, levelSliderP1;
    public TextMeshProUGUI vidaTxtP1, levelTxtP1;
    public Image faceP1;

    public Slider vidaSliderP2, levelSliderP2;
    public TextMeshProUGUI vidaTxtP2, levelTxtP2;
    public Image faceP2;

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
    }
    public void StartBattle()
    {
        if (!inBattle)
        {
            eventSystem.sendNavigationEvents = true;
            eventSystem.SetSelectedGameObject(firstButtonBattleStart);
            hudBattle.SetActive(true);

            //Cam
            camConfig.assetsPPU = (int)camSize.y;
            cam.enabled = false;

            //Player
            playerPosition = playerMove.transform.position;
            playerMove.enabled = false;
            playerMove.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

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
            PersonagemUnity p2 = playerFollow != null ? playerFollow.GetComponent<PersonagemUnity>() : null;
            battleManager.Battle(inimigosCombate, p1, p2);
        }
    }
    public void EndBattle()
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
        if (inimigo != null)
        {
            inimigo.resetPosition();
            inimigo.setInBattle(false);
        }
    }
    public void CriarPersonagem(Vector2 localSpawn, bool principal, string personagem)
    {
        GameObject player = (GameObject)Instantiate((GameObject)Resources.Load(personagem), localSpawn, Quaternion.identity);   
        player.transform.position = localSpawn;
        if (principal)
        {
            player.AddComponent<PlayerMove>();
            playerMove = player.GetComponent<PlayerMove>();
            PersonagemUnity aux = player.GetComponent<PersonagemUnity>();
            aux.vidaSlider = vidaSliderP1;
            aux.vidaTxt = vidaTxtP1;
            aux.levelSlider = levelSliderP1;
            aux.levelTxt = levelTxtP1;
            aux.face = faceP1;
        }
        else
        {
            Destroy(player.GetComponent<Rigidbody2D>());
            Destroy(player.GetComponent<BoxCollider2D>());
            player.AddComponent<PlayerFollow>();
            playerFollow = player.GetComponent<PlayerFollow>();
            PersonagemUnity aux = player.GetComponent<PersonagemUnity>();
            aux.vidaSlider = vidaSliderP2;
            aux.vidaTxt = vidaTxtP2;
            aux.levelSlider = levelSliderP2;
            aux.levelTxt = levelTxtP2;
            aux.face = faceP2;
        }
        

    }
    public void CriarInimigosCombate()
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
    public void ComecarJogo(Vector2 localSpawn)
    {
        cam = FindObjectOfType<CamMove>();
        CriarPersonagem(localSpawn, true, p1);
        if (multiplayer)
        {
            CriarPersonagem(localSpawn, false, p2);
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
}
