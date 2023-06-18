using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class Incisura : Habilidade
    {
        public Incisura()
        {
            Nome = "Incisura";
            Multiplicador = 1.5;
            Tier = 2;
            ClassType = 3;
            Nivel = 1;
            Custo = 48;
        }
    }
}
