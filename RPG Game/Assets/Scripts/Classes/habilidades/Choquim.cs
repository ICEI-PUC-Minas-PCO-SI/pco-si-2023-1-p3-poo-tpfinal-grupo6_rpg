using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class Choquim : Habilidade
    {
        public Choquim()
        {
            Nome = "Choquim";
            Multiplicador = 1.2;
            Tier = 1;
            ClassType = 2;
            Nivel = 1;
            Custo = 9;
        }
    }
}
