namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;

    public class AdjustableChair:Chair, IFurniture, IChair, IAdjustableChair
    {
        public AdjustableChair(string model, decimal price, decimal height, MaterialType material, int numberOfLegs)
            : base(model, price, height, material, numberOfLegs)
        {
            
        }

        public void SetHeight(decimal height)
        {
            this.Height = height;
        }

        public override string ToString()
        {
            return
                string.Format(
                    "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}",
                    this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs);
        }
    }
}
