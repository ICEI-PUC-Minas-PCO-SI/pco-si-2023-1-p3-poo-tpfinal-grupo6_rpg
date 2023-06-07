using RpgGame.models;
using RpgGame.view;
using System.Collections.Generic;
public interface IStatus
{
    public List<Habilidade> habilidades { get; }
    public Atributos atributo { get; }
}
