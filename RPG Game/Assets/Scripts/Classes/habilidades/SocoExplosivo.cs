using RpgGame.models;
namespace RpgGame.habilidades
{
    internal class SocoExplosivo : Habilidade
    {
        public SocoExplosivo()
        {
            Nome = "Soco explosivo";
            Multiplicador = 1.8;
            Tier = 3;
            Custo = 12;
            ClassType = 1;
            Nivel = 1;
        }
    }
}
