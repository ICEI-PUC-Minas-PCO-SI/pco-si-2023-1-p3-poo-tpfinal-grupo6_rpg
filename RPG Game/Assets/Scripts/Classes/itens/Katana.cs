using RpgGame.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.itens
{
    internal class Katana : ItemEquipavel
    {
        public Katana()
        {
            nome = "Katana";
            ItemMult = 1.3;
            Id = 14;
            TypeClass = 1;
        }
    }
}
