using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class LesaoConcentrada : Habilidade
    {
        public LesaoConcentrada()
        {
            Nome = "Lesão Concentrada";
            Multiplicador = 2.0;
            Tier = 4;
            ClassType = 3;
            Nivel = 1;
            Custo = 120;
        }
    }
}
