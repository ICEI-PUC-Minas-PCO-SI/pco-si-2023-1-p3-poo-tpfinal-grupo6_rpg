using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class Perfurar : Habilidade
    {
        public Perfurar() {
            Nome = "Perfurar";
            Multiplicador = 1.2;
            Tier = 1;
            ClassType = 1;
            Nivel = 1;
            Custo = 9;
        }
    }
}
