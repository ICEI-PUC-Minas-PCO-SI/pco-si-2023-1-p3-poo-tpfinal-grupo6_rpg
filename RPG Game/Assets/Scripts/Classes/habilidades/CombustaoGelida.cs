using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class CombustaoGelida : Habilidade
    {
        public CombustaoGelida()
        {
            Nome = "Combustão Gélida";
            Multiplicador = 1.7;
            Tier = 3;
            ClassType = 2;
            Nivel = 1;
            Custo = 65;
        }
        public CombustaoGelida(PersonagemMonstro m)
        {
            Nome = "Combustão Gélida";
            Multiplicador = 1.7;
            Tier = 3;
            ClassType = 2;
            Nivel = 1;
            Custo = 65;
        }
    }
}
