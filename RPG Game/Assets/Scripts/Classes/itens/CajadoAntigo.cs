using RpgGame.models;

namespace RpgGame.itens
{
    internal class CajadoAntigo : ItemEquipavel
    {
        public CajadoAntigo()
        {
            nome = "Cajado Antigo";
            ItemMult = 1.1;
            Id = 18;
            TypeClass = 2;
        }
    }
}
