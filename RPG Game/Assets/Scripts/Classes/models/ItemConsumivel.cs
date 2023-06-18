namespace RpgGame.models
{
    public abstract class ItemConsumivel : Item
    {
        public abstract void Usar(IStatus status);
    }
}
