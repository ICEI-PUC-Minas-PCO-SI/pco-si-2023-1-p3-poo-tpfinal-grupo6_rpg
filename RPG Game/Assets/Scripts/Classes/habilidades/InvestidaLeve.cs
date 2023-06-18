using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class InvestidaLeve : Habilidade
    {
        public InvestidaLeve()
        {
            Nome = "Investida Leve";
            Multiplicador = 1.2;
            Tier = 1;
            ClassType = 1;
            Nivel = 1;
            Custo = 10;
        }
    }
}
