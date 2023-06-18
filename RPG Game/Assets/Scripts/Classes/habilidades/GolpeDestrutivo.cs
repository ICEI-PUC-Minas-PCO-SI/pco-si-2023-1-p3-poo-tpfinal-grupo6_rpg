using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class GolpeDestrutivo : Habilidade
    {
        public GolpeDestrutivo()
        {
            Nome = "Golpe Destrutivo";
            Multiplicador = 1.6;
            Tier = 2;
            ClassType = 1;
            Nivel = 1;
            Custo = 40;
        }
    }
}
