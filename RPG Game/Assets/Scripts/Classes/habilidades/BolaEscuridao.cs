using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class BolaEscuridao : Habilidade
    {
        public BolaEscuridao()
        {
            Nome = "Bola Negra";
            Multiplicador = 1.8;
            Tier = 3;
            ClassType = 2;
            Nivel = 1;
            Custo = 70;
        }
    }
}
