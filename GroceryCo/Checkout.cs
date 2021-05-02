using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryCo
{
    class Checkout : Receipt
    {
        public static void ProcessCheckout(string basketFilePath)
        {
            CurrentPriceCatalogue.BuildCurrentPriceCatalogue(@"data\catalogue.txt");
            Promotions.ApplyPromotions(@"data\promotion.txt");
            Receipt.PrintReceipt(basketFilePath);
        }
        public static decimal CalculateTotalPrice()
        {
            decimal totalprice = 0;
            foreach (CatalogueItem item in ReceiptItems)
            {
                totalprice += item.Quantity * item.GetEffectivePrice();
            }
            return totalprice;
        }
    }
}
