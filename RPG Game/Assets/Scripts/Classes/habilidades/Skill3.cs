using RpgGame.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.habilidades
{
    internal class SkillThree : Habilidade //Remover
    {
        public SkillThree()
        {
            Nome = "Skill 3";
            Multiplicador = 99.0;
            Tier = 3;
        }
    }
}
