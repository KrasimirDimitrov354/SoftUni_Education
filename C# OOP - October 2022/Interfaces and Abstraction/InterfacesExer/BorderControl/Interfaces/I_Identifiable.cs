namespace BorderControl
{
    public interface I_Identifiable
    {
        public string Id { get; }

        public void Detain(string identifier);
    }
}
