namespace RpgGame.models
{
    public abstract class Habilidade
    {
        public string Nome { get; protected set; }
        public double Multiplicador { get; set; }
        public int Custo { get; set; }
        public int Tier { get; protected set; }
        public int Nivel { get; protected set; }
        public int ClassType { get; protected set; }
        //public abstract void Executar(Monstro alvo);
    }
}
