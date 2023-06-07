using RpgGame.models;

namespace RpgGame.itens
{
    public class PocaoCura : ItemConsumivel
    {
        public PocaoCura()
        {
            nome = "Poção de cura";
        }

        public override void Usar(PersonagemJogador p)
        {
            p.atributo.Hp += 25;
            if (p.atributo.Hp > p.atributo.MaxHp)
            {
                p.atributo.Hp = p.atributo.MaxHp;
            }
        }
    }
}
