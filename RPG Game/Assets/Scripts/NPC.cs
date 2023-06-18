using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string[] dialogo;
    public string nome;
    public Sprite face;
    public GameObject interact;

    private void Start()
    {
        interact.SetActive(false);
    }
    private void Update()
    {
        if (interact.activeSelf && Input.GetButtonDown("Submit"))
        {
            FindObjectOfType<DialogoManager>().ComecarConversa(face, dialogo, nome);
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
