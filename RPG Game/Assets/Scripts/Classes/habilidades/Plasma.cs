using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class Plasma : Habilidade
    {
        public Plasma()
        {
            Nome = "Plasma";
            Multiplicador = 1.2;
            Tier = 1;
            ClassType = 3;
            Nivel = 1;
            Custo = 9;
        }
    }
}
