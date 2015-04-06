namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Category : ICategory
    {
        private string name;

        public Category(string name)
        {
            this.Name = name;
            this.CosmeticsList = new List<IProduct>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, "Category name cannot be null or empty!");
                Validator.CheckIfStringLengthIsValid(value, 15, 2, string.Format("Category name must be between {0} and {1} symbols long!", 2, 15));
                this.name = value;
            }
        }

        public List<IProduct> CosmeticsList { get; private set; }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.CosmeticsList.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (!this.CosmeticsList.Contains(cosmetics))
            {
                throw new ArgumentException(string.Format("Product {0} does not exist in category {1}!", cosmetics.Name, this.Name));
            }
            this.CosmeticsList.Remove(cosmetics);
        }

        public string Print()
        {
            var sortedList = this.CosmeticsList.OrderBy(x => x.Brand).ThenByDescending(x => x.Price);
            var result = new StringBuilder(); 
            
            result.AppendLine(string.Format("{0} category - {1} {2} in total",
                this.Name, this.CosmeticsList.Count, this.CosmeticsList.Count == 1 ? "product" : "products"));
            foreach (var item in sortedList)
            {
                result.AppendLine(item.Print());
            }
           
            return result.ToString().TrimEnd();
        }
    }
}
