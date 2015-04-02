namespace TradeAndTravel
{
    public class Merchant : Shopkeeper, ITraveller, IShopkeeper
    {
        public Merchant(string name, Location location)
            : base(name, location)
        {
        }

        public void TravelTo(Location location)
        {
            this.Location = location;
        }

        public new int CalculateSellingPrice(Item item)
        {
            return item.Value;
        }

        public new int CalculateBuyingPrice(Item item)
        {
            return item.Value / 2;
        }
    }
}
