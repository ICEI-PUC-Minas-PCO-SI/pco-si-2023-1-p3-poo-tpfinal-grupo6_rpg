using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class CorteFocado : Habilidade
    {
        public CorteFocado()
        {
            Nome = "Corte focado";
            Multiplicador = 1.2;
            Tier = 1;
            ClassType = 3;
            Nivel = 1;
            Custo = 8;
        }
    }
}
