using RpgGame.models;

namespace RpgGame.itens
{
    internal class CajadoCarregado:ItemEquipavel
    {
        public CajadoCarregado()
        {
            nome = "Cajado Carregado";
            ItemMult = 1.2;
            Id = 19;
            TypeClass = 2;
        }
    }
}
