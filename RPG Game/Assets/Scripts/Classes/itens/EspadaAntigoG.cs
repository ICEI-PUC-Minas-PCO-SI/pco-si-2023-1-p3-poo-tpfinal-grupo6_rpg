using RpgGame.models;

namespace RpgGame.itens
{
    internal class EspadaAntigoG : ItemEquipavel
    {
        public EspadaAntigoG()
        {
            nome = "Espada do antigo guerreiro";
            ItemMult = 1.4;
            Id = 15;
            TypeClass = 1;
        }
    }
}
