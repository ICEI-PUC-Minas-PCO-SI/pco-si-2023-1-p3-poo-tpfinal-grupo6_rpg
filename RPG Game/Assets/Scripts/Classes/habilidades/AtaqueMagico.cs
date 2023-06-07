using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class AtaqueMagico : Habilidade
    {
        public AtaqueMagico()
        {
            Nome = "Ataque magico";
            Multiplicador = 1.2;
            Tier = 1;
        }
    }
}
