using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class GolpePesado : Habilidade
    {
        public GolpePesado()
        {
            Nome = "Golpe Pesado";
            Multiplicador = 1.8;
            Tier = 3;
            ClassType = 1;
            Nivel = 1;
            Custo = 60;
        }
    }
}
