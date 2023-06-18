using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class CorteIlusorio : Habilidade
    {
        public CorteIlusorio()
        {
            Nome = "Corte Ilusório";
            Multiplicador = 1.2;
            Tier = 1;
            ClassType = 3;
            Nivel = 1;
            Custo = 12;
        }
    }
}
