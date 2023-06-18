using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class MagiaBranca : Habilidade
    {
        public MagiaBranca()
        {
            Nome = "Mágia Branca";
            Multiplicador = 1.6;
            Tier = 3;
            ClassType = 2;
            Nivel = 1;
            Custo = 45;
        }
    }
}
