using RpgGame.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.habilidades
{
    internal class Genki_Dama : Habilidade //Remover
    {
        public Genki_Dama() {
            Nome = "Genki-Dama";
            Multiplicador = 2.5;
            Tier = 4;
        }
    }
}
