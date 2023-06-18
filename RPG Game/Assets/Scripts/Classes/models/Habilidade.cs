namespace RpgGame.models
{
    public abstract class Habilidade
    {
        public string Nome { get; protected set; }
        public double Multiplicador { get; protected set; }
        public int Dano { get; protected set; }
        public int Custo { get; protected set; }
        public int Tier { get; protected set; }
        public int Nivel { get; protected set; }
        public int ClassType { get; protected set; }
        //public abstract void Executar(Monstro alvo);
    }
}
