using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class HeadHunter : Habilidade
    {
        public HeadHunter()
        {
            Nome = "HeadHunter";
            Multiplicador = 1.6;
            Tier = 2;
            ClassType = 3;
            Nivel = 1;
            Custo = 45;
        }
    }
}
