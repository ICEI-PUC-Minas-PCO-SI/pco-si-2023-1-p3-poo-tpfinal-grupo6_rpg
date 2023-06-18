using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class GolpeBasico : Habilidade
    {
        public GolpeBasico()
        {
            Nome = "Golpe Basico";
            Multiplicador = 1.2;
            Tier = 1;
            ClassType = 1;
            Nivel = 1;
            Custo = 8;
        }
    }
}
