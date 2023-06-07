using RpgGame.models;
using RpgGame.view;
using System.Collections.Generic;

public abstract class PersonagemMonstro : Personagem, IStatus
{
    public int tier { get; protected set; }
    public List<Habilidade>? habilidades { get; protected set; }
    public Atributos atributo { get; protected set; }
}