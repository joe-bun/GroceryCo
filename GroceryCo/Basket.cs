using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryCo
{
    class Basket : CurrentPriceCatalogue
    {
        private static List<CatalogueItem> receiptItems = new();
        public static List<CatalogueItem> ReceiptItems { get => receiptItems; set => receiptItems = value; }
        public static void ScanBasketItems(string basketFilePath)
        {
            List<string> lines = File.ReadAllLines(basketFilePath).ToList();
            foreach (string line in lines)
            {
                foreach (CatalogueItem item in CatalogueItems)
                {
                    if (line == item.Name)
                    {
                        item.Quantity += 1;
                        if (!ReceiptItems.Contains(item))
                        {
                            ReceiptItems.Add(item);
                        }
                    }
                }
            }
        }
    }
}
