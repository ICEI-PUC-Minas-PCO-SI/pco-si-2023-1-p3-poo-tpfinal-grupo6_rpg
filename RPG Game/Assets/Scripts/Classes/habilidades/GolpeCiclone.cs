using RpgGame.models;

namespace RpgGame.habilidades
{
    internal class GolpeCiclone : Habilidade
    {
        public GolpeCiclone()
        {
            Nome = "Golpe Ciclone";
            Multiplicador = 1.8;
            Tier = 3;
            ClassType = 1;
            Nivel = 1;
            Custo = 70;
        }
        public GolpeCiclone(PersonagemMonstro m)
        {
            Nome = "Golpe Ciclone";
            Multiplicador = 1.8;
            Tier = 3;
            ClassType = 1;
            Nivel = 1;
            Custo = 70;
        }
    }
}
