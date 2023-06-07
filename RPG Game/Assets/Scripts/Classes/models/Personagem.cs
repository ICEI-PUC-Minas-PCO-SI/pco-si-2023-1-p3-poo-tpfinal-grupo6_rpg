using UnityEngine;

public abstract class Personagem
{
    private string nome;

    public void setNome(string nome) { this.nome = nome;  }
    public string getNome() { return nome; }
}