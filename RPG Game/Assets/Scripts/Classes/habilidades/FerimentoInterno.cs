using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class FerimentoInterno : Habilidade
    {
        public FerimentoInterno()
        {
            Nome = "Ferimento interno";
            Multiplicador = 1.5;
            Tier = 2;
            ClassType = 3;
            Nivel = 1;
            Custo = 32;
        }
    }
}
