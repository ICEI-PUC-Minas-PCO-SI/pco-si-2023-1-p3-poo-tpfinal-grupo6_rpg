using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class FioDoDestino : Habilidade
    {
        public FioDoDestino()
        {
            Nome = "Fio do Destino";
            Multiplicador = 1.6;
            Tier = 3;
            ClassType = 3;
            Nivel = 1;
            Custo = 60;
        }
        public FioDoDestino(PersonagemMonstro m)
        {
            Nome = "Fio do Destino";
            Multiplicador = 1.6;
            Tier = 3;
            ClassType = 3;
            Nivel = 1;
            Custo = 60;
        }
    }
}
