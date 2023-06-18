using RpgGame.models;

namespace RpgGame.itens
{
    internal class EspadaFerro : ItemEquipavel
    {
        public EspadaFerro()
        {
            nome = "Espada de Ferro";
            ItemMult = 1.1;
            Id = 12;
            TypeClass = 1;
        }
    }
}
