using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class CortesFantasmas : Habilidade
    {
        public CortesFantasmas()
        {
            Nome = "Cortes Fantasmas";
            Multiplicador = 1.2;
            Tier = 1;
            ClassType = 3;
            Nivel = 1;
            Custo = 22;
        }
        public CortesFantasmas(PersonagemMonstro m)
        {
            Nome = "Cortes Fantasmas";
            Multiplicador = 1.2;
            Tier = 1;
            ClassType = 3;
            Nivel = 1;
            Custo = 22;
        }
    }
}
