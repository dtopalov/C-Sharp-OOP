namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    public class Table : Furniture, IFurniture, ITable
    {
        private decimal length;
        private decimal width;

        public Table(string model, decimal price, decimal height, MaterialType material, decimal length, decimal width)
            :base(model, price, height, material)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Length
        {
            get { return this.length; }
            set
            {
                if (value <= 0.0m)
                {
                    throw new ArgumentOutOfRangeException("Length cannot be <= 0.00");
                }
                this.length = value;
            }
        }

        public decimal Width
        {
            get { return this.width; }
            set
            {
                if (value <= 0.0m)
                {
                    throw new ArgumentOutOfRangeException("Width cannot be <= 0.00");
                }
                this.width = value;
            }
        }

        public decimal Area
        {
            get { return this.Length*this.Width; }
        }

        public override string ToString()
        {
            return
                string.Format(
                    "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Length: {5}, Width: {6}, Area: {7}",
                    this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.Length, this.Width,
                    this.Area);
        }
    }
}
