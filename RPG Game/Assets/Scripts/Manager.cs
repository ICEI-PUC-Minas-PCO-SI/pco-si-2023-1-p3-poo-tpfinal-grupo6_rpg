using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class Manager : MonoBehaviour
{
    public bool multiplayer;
    public GameObject hudPlayer2, hudBattle;
    EventSystem eventSystem;
    public GameObject firstButtonBattleStart;

    PixelPerfectCamera camConfig;
    public Vector2 camSize;
    CamMove cam;
    public float distanceCamera, cameraHeight;

    PlayerMove playerMove;
    PlayerFollow playerFollow;
    InimigoMove inimigo;
    Vector2 playerPosition;

    public Transform localSpawn;

    List<Personagem> personagems = new List<Personagem>();

    void Awake()
    {
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
        if(multiplayer)
        {
            playerFollow.enabled = false;
            playerMove.transform.position = (Vector2)cam.transform.position - new Vector2(distanceCamera, -1.5f);
            playerFollow.transform.position = (Vector2)cam.transform.position - new Vector2(distanceCamera, 1.5f);
        }
        else
        {
            playerMove.transform.position = (Vector2)cam.transform.position - new Vector2(distanceCamera, 0);
        }
        inimigo.transform.position = (Vector2)cam.transform.position + new Vector2(distanceCamera, 0);
        
        //Ajuste Cam
        cam.transform.position -= new Vector3(0, cameraHeight, 0);
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
    public void CriarPersonagem(Vector2 localSpawn, bool principal)
    {
        GameObject player = (GameObject)Instantiate((GameObject)Resources.Load("Ninja"), localSpawn, Quaternion.identity);
        player.AddComponent<PlayerMove>();
        playerMove = player.GetComponent<PlayerMove>();
        player.transform.position = localSpawn;
        playerMove.GetComponent<PersonagemUnity>().setPlayer(principal);

    }
    public void ComecarJogo(Vector2 localSpawn)
    {
        cam = FindObjectOfType<CamMove>();
        CriarPersonagem(localSpawn, true);
        hudPlayer2.SetActive(multiplayer);
        if (multiplayer)
        {
            GameObject player2 = Instantiate((GameObject)Resources.Load("Player2"), playerMove.transform.position, Quaternion.identity);
            playerFollow = player2.GetComponent<PlayerFollow>();
        }
    }
    public void setInimigo(InimigoMove i)
    {
        inimigo = i;
    }
}
