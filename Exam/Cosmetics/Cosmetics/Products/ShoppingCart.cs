namespace Cosmetics.Products
{
    using System.Collections.Generic;
    using System.Linq;
    using Cosmetics.Contracts;

    public class ShoppingCart : IShoppingCart
    {
        public ShoppingCart()
        {
            this.ShoppingCartContents = new List<IProduct>();
        }

        public List<IProduct> ShoppingCartContents { get; private set; }

        public void AddProduct(IProduct product)
        {
            this.ShoppingCartContents.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.ShoppingCartContents.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.ShoppingCartContents.Contains(product);
        }

        public decimal TotalPrice()
        {
            return this.ShoppingCartContents.Select(x => x.Price).Sum();
        }
    }
}
