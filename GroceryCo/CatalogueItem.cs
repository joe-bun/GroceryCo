using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryCo
{
    class CatalogueItem
    {
        public string name;
        public decimal price;
        public bool onSale;
        public decimal onSalePrice;
        public int quantity;

        public CatalogueItem(string name, string price)
        {
            this.name = name;
            this.price = Convert.ToDecimal(price);        
        }

        public decimal setOnSalePrice(string promotionalPrice) => this.onSalePrice = Convert.ToDecimal(promotionalPrice);
        public decimal getEffectivePrice()
        {
                return onSale ? onSalePrice : price;
        }
        public string getItem() => name;
        public void addItemToReceipt(string name)
        {

        }
    }
}
