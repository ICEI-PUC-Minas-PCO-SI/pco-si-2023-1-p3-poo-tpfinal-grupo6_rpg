using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class Meteoro : Habilidade //Remover
    {
        public Meteoro() {
            Nome = "Meteoro";
            Multiplicador = 2.0;
            Tier = 4;
            ClassType = 2;
            Nivel = 1;
            Custo = 140;
        }
        public Meteoro(PersonagemMonstro m) //Ataque em Área
        {
            Nome = "Meteoro";
            Multiplicador = 2.0;
            Tier = 4;
            ClassType = 2;
            Nivel = 1;
            Custo = 140;
        }
    }
}
