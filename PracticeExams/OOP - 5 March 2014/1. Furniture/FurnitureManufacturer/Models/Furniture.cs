namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    public abstract class Furniture : IFurniture
    {
        private string model;
        private decimal price;
        private decimal height;

        protected Furniture(string model, decimal price, decimal height, MaterialType material)
        {
            this.Model = model;
            this.Price = price;
            this.Height = height;
            this.Material = material.ToString();
        }

        public string Model {
            get { return this.model; }
            protected set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("Model cannot be null, empty or shorter than 3 symbols", value);
                }
                this.model = value;
            }
        }

        public string Material { get; protected set; }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0.0m)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be <= 0.00");
                }
                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0.0m)
                {
                    throw new ArgumentOutOfRangeException("Height cannot be <= 0.00");
                }
                this.height = value;
            }
        }
    }
}
