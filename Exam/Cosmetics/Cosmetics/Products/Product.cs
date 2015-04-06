namespace Cosmetics.Products
{
    using System;
    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public abstract class Product : IProduct
    {
        private string name;
        private string brand;
        private decimal price;
        private GenderType gender;

        protected Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, "Product name cannot be null or empty!");
                Validator.CheckIfStringLengthIsValid(value, 10, 3, string.Format("Product name must be between {0} and {1} symbols long!", 3, 10));
                this.name = value;
            }
        }

        public string Brand
        {
            get { return this.brand; }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, "Brand name cannot be null or empty!");
                Validator.CheckIfStringLengthIsValid(value, 10, 2, string.Format("Product brand must be between {0} and {1} symbols long!", 2, 10));
                this.brand = value;
            }
        }

        public virtual decimal Price
        {
            get { return this.price; }
            private set
            {
                if (value < 0.0m)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be < 0!");
                }
                this.price = value;
            }
        }

        public Common.GenderType Gender
        {
            get { return this.gender; }
            private set
            {
                Validator.CheckIfNull(value, "Brand cannot be null!");
                this.gender = value;
            }
        }

        public virtual string Print()
        {
            return string.Format("- {0} - {1}:{2}  * Price: ${3}{2}  * For gender: {4}",
                this.Brand, this.Name, Environment.NewLine, this.Price, this.Gender).TrimEnd();
        }
    }
}
