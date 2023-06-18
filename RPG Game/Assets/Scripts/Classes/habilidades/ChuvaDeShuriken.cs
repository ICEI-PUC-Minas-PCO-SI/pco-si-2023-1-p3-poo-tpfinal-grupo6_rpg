using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class ChuvaDeShuriken : Habilidade
    {
        public ChuvaDeShuriken()
        {
            Nome = "Chuva de shuriken";
            Multiplicador = 1.2;
            Tier = 1;
            Custo = 5;
            ClassType = 3;
            Nivel = 1;
        }
    }
}
