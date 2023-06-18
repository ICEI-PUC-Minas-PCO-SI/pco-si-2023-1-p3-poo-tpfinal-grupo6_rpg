using RpgGame.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.itens
{
    internal class EspadaRuina : ItemEquipavel
    {
        public EspadaRuina()
        {
            nome = "Espada da Ruína";
            ItemMult = 1.6;
            Id = 16;
            TypeClass = 1;
        }
    }
}
