using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class FendaDimensional : Habilidade
    {
        public FendaDimensional() {
            Nome = "Fenda Dimensional";
            Multiplicador = 2.4;
            Tier = 4;
            ClassType = 3;
            Nivel = 1;
            Custo = 160;
        }
        public FendaDimensional(PersonagemMonstro m)
        {
            Nome = "Fenda Dimensional";
            Multiplicador = 2.4;
            Tier = 4;
            ClassType = 3;
            Nivel = 1;
            Custo = 160;
        }
    }
}
