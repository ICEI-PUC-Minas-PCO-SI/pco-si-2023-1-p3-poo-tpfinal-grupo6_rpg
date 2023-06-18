using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class GolpeEsmagador : Habilidade
    {
        public GolpeEsmagador()
        {
            Nome = "Golpe Esmagador";
            Multiplicador = 1.4;
            Tier = 2;
            ClassType = 1;
            Nivel = 1;
            Custo = 22;
        }
    }
}
