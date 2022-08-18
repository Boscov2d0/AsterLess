namespace BullsAndCows
{
    internal sealed class Model : IModel
    {
        public string Number { get; set; }
        public Model(string number)
        {
            Number = number;
        }
    }
}