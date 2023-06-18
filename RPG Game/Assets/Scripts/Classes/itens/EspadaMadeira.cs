using RpgGame.models;

namespace RpgGame.itens
{
    public class EspadaMadeira : ItemEquipavel
    {
        public EspadaMadeira()
        {
            nome = "Espada de madeira";
            ItemMult = 1;
            Id = 3;
            TypeClass = 1;
        }
    }
}
