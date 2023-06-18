using RpgGame.models;

namespace RpgGame.itens
{
    internal class AdagasDourada : ItemEquipavel
    {
        public AdagasDourada()
        {
            nome = "Adagas dourada";
            ItemMult = 1.3;
            Id = 8;
            TypeClass = 3;
        }
    }
}
