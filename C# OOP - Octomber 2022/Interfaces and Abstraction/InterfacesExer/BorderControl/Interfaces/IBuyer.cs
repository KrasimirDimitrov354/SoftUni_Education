namespace BorderControl
{
    public interface IBuyer : I_Identifiable
    {
        public int Food { get; }

        public void BuyFood();
    }
}
