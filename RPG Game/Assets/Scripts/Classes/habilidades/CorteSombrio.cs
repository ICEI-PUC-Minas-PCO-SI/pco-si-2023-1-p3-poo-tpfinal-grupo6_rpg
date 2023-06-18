using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class CorteSombrio : Habilidade 
    {
        public CorteSombrio()
        {
            Nome = "Corte Sombrio";
            Multiplicador = 1.6;
            Tier = 3;
            ClassType = 3;
            Nivel = 1;
            Custo = 35;
        }
    }
}
