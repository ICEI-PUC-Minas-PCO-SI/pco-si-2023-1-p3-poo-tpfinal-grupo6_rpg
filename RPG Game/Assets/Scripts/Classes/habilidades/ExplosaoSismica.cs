using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class ExplosaoSismica : Habilidade
    {
        public ExplosaoSismica()
        {
            Nome = "Explosão Sismica";
            Multiplicador = 2.2;
            Tier = 4;
            ClassType = 1;
            Nivel = 1;
            Custo = 150;
        }
    }
}
