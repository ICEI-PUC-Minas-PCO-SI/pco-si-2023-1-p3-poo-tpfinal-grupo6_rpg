using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class Empalar : Habilidade
    {
        public Empalar()
        {
            Nome = "Empalar";
            Multiplicador = 1.4;
            Tier = 2;
            ClassType = 1;
            Nivel = 1;
            Custo = 26;
        }
    }
}
