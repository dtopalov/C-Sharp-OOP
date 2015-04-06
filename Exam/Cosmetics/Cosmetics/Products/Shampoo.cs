namespace Cosmetics.Products
{
    using System;
    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Shampoo : Product, IProduct, IShampoo
    {
        private UsageType usage;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
        }

        public override decimal Price
        {
            get
            {
                return base.Price * this.Milliliters;
            }
        }

        public uint Milliliters { get; private set; }

        public UsageType Usage
        {
            get { return this.usage; }
            set
            {
                Validator.CheckIfNull(value, "Shampoo usage cannot be null!");
                this.usage = value;
            }
        }

        public override string Print()
        {
            return (base.Print() + 
                string.Format("{0}  * Quantity: {1} ml{0}  * Usage: {2}", Environment.NewLine, this.Milliliters, this.Usage))
                .TrimEnd();
        }
    }
}
