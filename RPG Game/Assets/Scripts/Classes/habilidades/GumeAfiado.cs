using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class GumeAfiado : Habilidade
    {
        public GumeAfiado()
        {
            Nome = "Gume Afiado";
            Multiplicador = 1.4;
            Tier = 2;
            ClassType = 3;
            Nivel = 1;
            Custo = 25;
        }
    }
}
