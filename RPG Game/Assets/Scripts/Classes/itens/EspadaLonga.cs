using RpgGame.models;

namespace RpgGame.itens
{
    internal class EspadaLonga : ItemEquipavel
    {
        public EspadaLonga()
        {
            nome = "Espada longa";
            ItemMult = 1.2;
            Id = 13;
            TypeClass = 1;
        }
    }
}
