using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public bool multiplayer;

    PixelPerfectCamera camConfig;
    public Vector2 camSize;
    CamMove cam;

    public float distanceCamera;
    PlayerMove playerMove;
    PlayerFollow playerFollow;
    InimigoMove inimigo;

    void Awake()
    {
        camConfig = FindObjectOfType<PixelPerfectCamera>();
        camConfig.refResolutionX = Screen.width;
        camConfig.refResolutionY = Screen.height;
        foreach(CanvasScaler aux in FindObjectsOfType<CanvasScaler>())
        {
            aux.referenceResolution = new Vector2(Screen.width, Screen.height);
        }
        cam = FindObjectOfType<CamMove>();
        playerMove = FindObjectOfType<PlayerMove>();

        if (multiplayer)
        {
             GameObject player2 = (GameObject)Resources.Load("Player2");
            player2 = Instantiate(player2, playerMove.transform.position, Quaternion.identity);
            playerFollow = FindObjectOfType<PlayerFollow>();
        }
    }
    public void StartBattle()
    {
        camConfig.assetsPPU = (int)camSize.y;
        playerFollow.enabled = false;
        playerMove.enabled = false;
        playerMove.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        cam.enabled = false;
        if(multiplayer)
        {
            playerMove.transform.position = (Vector2)cam.transform.position - new Vector2(distanceCamera, -1.5f);
            playerFollow.transform.position = (Vector2)cam.transform.position - new Vector2(distanceCamera, 1.5f);
        }
        else
        {
            playerMove.transform.position = (Vector2)cam.transform.position - new Vector2(distanceCamera, 0);
        }
        inimigo.transform.position = (Vector2)cam.transform.position + new Vector2(distanceCamera, 0);
    }
    public void EndBattle()
    {
        camConfig.assetsPPU = (int)camSize.x;
        playerMove.enabled = true;
        playerFollow.enabled = true;
        cam.enabled = true;
        if (inimigo != null)
            inimigo.setInBattle(false);
    }
    public void setInimigo(InimigoMove i)
    {
        inimigo = i;
    }
}
