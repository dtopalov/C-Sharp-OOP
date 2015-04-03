using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class ConvertibleChair : Chair, IFurniture, IChair, IConvertibleChair
    {
        private readonly decimal InitialHeight;

        public ConvertibleChair(string model, decimal price, decimal height, MaterialType material, int numberOfLegs)
            : base(model, price, height, material, numberOfLegs)
        {
            this.IsConverted = false;
            this.InitialHeight = height;
        }

        public bool IsConverted { get; private set; }

        public void Convert()
        {
            this.Height = IsConverted ? InitialHeight : 0.10m;
            this.IsConverted = !this.IsConverted;
        }

        public override string ToString()
        {
            return string.Format(
                "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}, State: {6}",
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs,
                this.IsConverted ? "Converted" : "Normal");
        }
    }
}
