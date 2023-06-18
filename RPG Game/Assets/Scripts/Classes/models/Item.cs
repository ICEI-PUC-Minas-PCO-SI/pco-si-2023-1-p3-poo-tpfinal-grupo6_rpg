namespace RpgGame.models
{
    public abstract class Item
    {
        public string nome { get; protected set; }
        public int Id { get; protected set; }
        public int TypeClass { get; protected set; }

    }
}
