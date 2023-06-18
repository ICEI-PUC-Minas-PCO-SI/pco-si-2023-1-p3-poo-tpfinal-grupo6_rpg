using RpgGame.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.habilidades
{
    internal class GrandeCorte : Habilidade
    {
        public GrandeCorte() {

            Nome = "Grande Corte Frontal";
            Multiplicador = 1.2;
            Tier = 1;
            ClassType = 1;
            Nivel = 1;
            Custo = 18;
        }
        public GrandeCorte(PersonagemMonstro m)
        {

            Nome = "Grande Corte Frontal";
            Multiplicador = 1.2;
            Tier = 1;
            ClassType = 1;
            Nivel = 1;
            Custo = 18;
        }
    }
}
