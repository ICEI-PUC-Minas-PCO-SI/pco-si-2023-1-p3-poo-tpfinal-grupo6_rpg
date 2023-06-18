using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class InvestidaPesada : Habilidade
    {
        public InvestidaPesada()
        {
            Nome = "Investida Pesada";
            Multiplicador = 1.7;
            Tier = 3;
            ClassType = 1;
            Nivel = 1;
            Custo = 50;
        }
    }
}
