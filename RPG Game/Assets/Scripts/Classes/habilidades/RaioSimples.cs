using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class RaioSimples : Habilidade
    {
        public RaioSimples()
        {
            Nome = "Raio simples";
            Multiplicador = 1.4;
            Tier = 2;
            ClassType = 2;
            Nivel = 1;
            Custo = 22;
        }
    }
}
