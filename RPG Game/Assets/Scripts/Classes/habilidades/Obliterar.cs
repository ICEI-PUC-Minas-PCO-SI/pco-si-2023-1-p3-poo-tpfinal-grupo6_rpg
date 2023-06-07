using RpgGame.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.habilidades
{
    internal class Obliterar : Habilidade //Remover
    {
        public Obliterar()
        {
            Nome = "Obliterar";
            Multiplicador = 2.6;
            Tier = 4;
        }
    }
}
