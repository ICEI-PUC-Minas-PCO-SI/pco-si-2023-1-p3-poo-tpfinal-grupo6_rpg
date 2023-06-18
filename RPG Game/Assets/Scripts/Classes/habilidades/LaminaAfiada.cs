using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class LaminaAfiada : Habilidade
    {
        public LaminaAfiada()
        {
            Nome = "Lamina Afiada";
            Multiplicador = 1.4;
            Tier = 2;
            ClassType = 3;
            Nivel = 1;
            Custo = 26;
        }
    }
}
