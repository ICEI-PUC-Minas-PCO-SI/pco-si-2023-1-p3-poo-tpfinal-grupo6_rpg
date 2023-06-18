using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class Obliterar : Habilidade 
    {
        public Obliterar()
        {
            Nome = "Obliterar";
            Multiplicador = 2.2;
            Tier = 4;
            ClassType = 2;
            Nivel = 1;
            Custo = 120;
        }
    }
}
