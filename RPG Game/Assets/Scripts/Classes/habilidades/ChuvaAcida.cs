using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class ChuvaAcida : Habilidade
    {
        public ChuvaAcida()
        {
            Nome = "Chuva Ácida";
            Multiplicador = 1.2;
            Tier = 1;
            ClassType = 2;
            Nivel = 1;
            Custo = 22;
        }
        public ChuvaAcida(PersonagemMonstro m)
        {
            Nome = "Chuva Ácida";
            Multiplicador = 1.2;
            Tier = 1;
            ClassType = 2;
            Nivel = 1;
            Custo = 22;
        }
    }
}
