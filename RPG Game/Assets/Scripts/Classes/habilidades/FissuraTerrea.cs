using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class FissuraTerrea : Habilidade
    {
        public FissuraTerrea()
        {
            Nome = "Físsura Térrea";
            Multiplicador = 1.4;
            Tier = 2;
            ClassType = 1;
            Nivel = 1;
            Custo = 32;
        }
        public FissuraTerrea(PersonagemMonstro m)
        {
            Nome = "Físsura Térrea";
            Multiplicador = 1.4;
            Tier = 2;
            ClassType = 1;
            Nivel = 1;
            Custo = 32;
        }
    }
}
