using System;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class Chair : Furniture, IFurniture, IChair
    {
        private int numberOfLegs;

        public Chair(string model, decimal price, decimal height, MaterialType material, int numberOfLegs)
            : base(model, price, height, material)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs {
            get { return this.numberOfLegs; }
            protected set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Number of legs cannot be < 1");
                }
                this.numberOfLegs = value;
            }
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
