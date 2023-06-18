using RpgGame.models;
namespace RpgGame.habilidades
{
    internal class SocoForte : Habilidade
    {
        public SocoForte()
        {
            Nome = "Soco Forte";
            Multiplicador = 1.8;
            Tier = 3;
            Custo = 8;
            ClassType = 1;
            Nivel = 1;
        }
    }
}
