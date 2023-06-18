using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class CissuraOssea : Habilidade
    {
        public CissuraOssea()
        {
            Nome = "Cissura Óssea";
            Multiplicador = 1.4;
            Tier = 2;
            ClassType = 1;
            Nivel = 1;
            Custo = 26;
        }
    }
}
