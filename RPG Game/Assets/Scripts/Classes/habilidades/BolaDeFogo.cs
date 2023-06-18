using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class BolaDeFogo : Habilidade
    {
        public BolaDeFogo()
        {
            Nome = "Bola de fogo";
            Multiplicador = 1.2;
            Tier = 1;
            ClassType = 2;
            Nivel = 1;
            Custo = 10;
        }
    }
}
