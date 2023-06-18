using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class PedraGelo : Habilidade
    {
        public PedraGelo()
        {
            Nome = "Pedra de Gelo";
            Multiplicador = 1.4;
            Tier = 1;
            ClassType = 2;
            Nivel = 1;
            Custo = 18;
        }
    }
}
