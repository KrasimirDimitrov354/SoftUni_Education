namespace BorderControl
{
    public class Robot : Person
    {
        public Robot(string model, string id)
            : base(id)
        {
            Model = model;
        }

        public string Model { get; private set; }
    }
}
