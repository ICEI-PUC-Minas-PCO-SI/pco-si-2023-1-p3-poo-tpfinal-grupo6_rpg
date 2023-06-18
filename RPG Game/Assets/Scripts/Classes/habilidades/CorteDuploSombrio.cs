using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class CorteDuploSombrio : Habilidade
    {
        public CorteDuploSombrio()
        {
            Nome = "Corte Duplo Sombrio";
            Multiplicador = 1.8;
            Tier = 3;
            ClassType = 3;
            Nivel = 1;
            Custo = 60;
        }
    }
}
