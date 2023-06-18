using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class CorteRapido : Habilidade
    {
        public CorteRapido()
        {
            Nome = "Corte Rapido";
            Multiplicador = 1.2;
            Tier = 1;
            ClassType = 3;
            Nivel = 1;
            Custo = 10;
        }
    }
}
