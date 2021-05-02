using System;

namespace GroceryCo
{
    public class CatalogueItem
    {
        private readonly string name;
        private readonly decimal price;
        private bool isOnSale;
        private decimal onSalePrice;
        private int quantity;

        public CatalogueItem(string name, string price)
        {
            this.name = name;
            this.price = Convert.ToDecimal(price);
        }

        public decimal OnSalePrice { get => onSalePrice; set => onSalePrice = value; }

        public string Name => name;

        public decimal Price => price;

        public bool IsOnSale { get => isOnSale; set => isOnSale = value; }
        public int Quantity { get => quantity; set => quantity = value; }
   
        public decimal GetEffectivePrice()
        {
            return IsOnSale ? OnSalePrice : Price;
        }
    }
}
