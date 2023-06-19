using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bau : MonoBehaviour
{
    public GameObject interact;
    PlayerData playerData;
    public ItemObjeto[] listaItens;

    private void Start()
    {
        playerData = FindObjectOfType<PlayerData>();
        interact.SetActive(false);
    }
    private void Update()
    {
        if (interact.activeSelf && Input.GetButtonDown("Submit"))
        {
            if(playerData.AdicionarItemMochila(listaItens[Random.Range(0, listaItens.Length)]))
                Destroy(gameObject);
            interact.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            interact.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            interact.SetActive(false);
    }
}
