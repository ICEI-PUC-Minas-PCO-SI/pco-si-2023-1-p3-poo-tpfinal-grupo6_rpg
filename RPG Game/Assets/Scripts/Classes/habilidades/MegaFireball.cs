using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class MegaFireball : Habilidade
    {
        public MegaFireball()
        {
            Nome = "Mega bola de fogo";
            Multiplicador = 1.4;
            Tier = 2;
            ClassType = 2;
            Nivel = 1;
            Custo = 22;
        }
    }
}
