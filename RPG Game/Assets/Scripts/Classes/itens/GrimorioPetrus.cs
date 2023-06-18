using RpgGame.Interface;
using RpgGame.models;

namespace RpgGame.itens
{
    internal class GrimorioPetrus:ItemEquipavel,IDestruction
    {
        public GrimorioPetrus()
        {
            nome = "Grimório de Pétrus";
            ItemMult = 1.8;
            Id = 23;
            TypeClass = 2;
        }
        public void Destruction()
        {
            //Logica para causar 20% de dano extra a cada golpe 
        }
    }
}
