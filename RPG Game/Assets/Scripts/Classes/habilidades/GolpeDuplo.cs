using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class GolpeDuplo : Habilidade
    {
        public GolpeDuplo()
        {
            Nome = "Golpe Duplo";
            Multiplicador = 1.2;
            Tier = 1;
            ClassType = 1;
            Nivel = 1;
            Custo = 12;
        }
    }
}
