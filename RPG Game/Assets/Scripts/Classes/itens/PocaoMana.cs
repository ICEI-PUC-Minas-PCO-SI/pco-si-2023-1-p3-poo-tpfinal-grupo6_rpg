using RpgGame.Interface;
using RpgGame.models;

namespace RpgGame.itens
{
    internal class PocaoMana : ItemConsumivel
    {
        public PocaoMana()
        {
            nome = "Poção de cura restaura o HP em 25%";
            Id = 2;
        }
        public override void Usar(IStatus status)
        {
            double recovery = status.atributo.MaxMana * 0.25;
            status.atributo.Mana += (int)recovery;
            if (status.atributo.Mana > status.atributo.MaxMana)
            {
                status.atributo.Mana = status.atributo.MaxMana;
            }
        }

    }
}
