using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class AtaqueBasico : Habilidade
    {
        public AtaqueBasico()
        {
            Nome = "Ataque basico";
            Multiplicador = 1;
            Tier = 0;
            Custo = 0;
            Dano = 6;
        }
    }
}
