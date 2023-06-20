using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class ChuvaDeShuriken : Habilidade
    {
        public ChuvaDeShuriken()
        {
            Nome = "Chuva de shuriken";
            Multiplicador = 1.6;
            Tier = 1;
            Custo = 3;
            ClassType = 3;
            Nivel = 1;
        }
    }
}
