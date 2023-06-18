using RpgGame.models;

namespace RpgGame.itens
{
    public class CajadoSimples : ItemEquipavel
    {
        public CajadoSimples()
        {
            nome = "Cajado Simples";
            ItemMult = 1;
            Id = 4;
            TypeClass = 2;
        }
    }
}
