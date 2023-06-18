using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class TendrilFlamejante : Habilidade
    {
        public TendrilFlamejante()
        {
            Nome = "Tendril Flamejante";
            Multiplicador = 1.6;
            Tier = 2;
            ClassType = 2;
            Nivel = 1;
            Custo = 40;
        }
    }
}
