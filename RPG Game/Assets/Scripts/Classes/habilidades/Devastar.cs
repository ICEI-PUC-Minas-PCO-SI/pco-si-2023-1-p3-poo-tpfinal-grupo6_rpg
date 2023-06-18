using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class Devastar : Habilidade
    {
        public Devastar()
        {
            Nome = "Devastar";
            Multiplicador = 2.2;
            Tier = 4;
            ClassType = 1;
            Nivel = 1;
            Custo = 100;
        }
    }
}
