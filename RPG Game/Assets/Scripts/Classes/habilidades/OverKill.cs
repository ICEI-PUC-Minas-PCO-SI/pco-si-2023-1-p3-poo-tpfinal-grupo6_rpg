using RpgGame.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.habilidades
{
    internal class OverKill : Habilidade //Remover
    {
        public OverKill()
        {
            Nome = "Overkill";
            Multiplicador = 99.0;
            Tier = 4;
        }
    }
}
