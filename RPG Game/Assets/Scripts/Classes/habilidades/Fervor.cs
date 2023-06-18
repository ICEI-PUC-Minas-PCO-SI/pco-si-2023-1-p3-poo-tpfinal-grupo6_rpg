using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class Fervor : Habilidade
    {
        public Fervor()
        {
            Nome = "Fervor";
            Multiplicador = 1.4;
            Tier = 2;
            ClassType = 2;
            Nivel = 1;
            Custo = 26;
        }
    }
}
