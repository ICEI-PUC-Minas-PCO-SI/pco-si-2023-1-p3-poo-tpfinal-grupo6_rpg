using RpgGame.models;

namespace RpgGame.itens
{
    internal class AdagaFerro : ItemEquipavel
    {
        public AdagaFerro()
        {
            nome = "Adagas de Ferro";
            ItemMult = 1.1;
            Id = 6;
            TypeClass = 3;
        }
    }
}
