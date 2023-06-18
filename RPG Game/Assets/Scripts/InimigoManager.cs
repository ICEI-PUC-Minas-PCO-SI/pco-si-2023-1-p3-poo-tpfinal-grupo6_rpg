using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoManager : MonoBehaviour
{
    public Sprite[] spriteInimigos;
    public GameObject localInimigos;
    List<Transform> localSpawn;
    public GameObject inimigoBase;
    void Awake()
    {
        localSpawn = new List<Transform>();
        localSpawn.AddRange(localInimigos.GetComponentsInChildren<Transform>());
        localSpawn.RemoveAt(0);
        foreach (Transform t in localSpawn)
        {
            GameObject aux =  (GameObject)Instantiate(inimigoBase, t.position, Quaternion.identity);
            aux.GetComponent<SpriteRenderer>().sprite = spriteInimigos[Random.Range(0, spriteInimigos.Length)];
        }
    }
}
