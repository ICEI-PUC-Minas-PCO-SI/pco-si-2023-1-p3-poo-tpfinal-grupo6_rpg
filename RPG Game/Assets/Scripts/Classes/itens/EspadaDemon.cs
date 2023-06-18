using RpgGame.models;
using RpgGame.Interface;

namespace RpgGame.itens
{
    internal class EspadaDemon : ItemEquipavel, IInfernus
    {
        public EspadaDemon()
        {
            nome = "Espada do rei demônio";
            ItemMult = 1.8;
            Id = 17;
            TypeClass = 1;
        }
        public void Infernus()
        {
            //Logica para queimar todos inimigos em 10% a cada golpe
        }
    }
}
