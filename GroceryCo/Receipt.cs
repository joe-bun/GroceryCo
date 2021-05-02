using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GroceryCo
{
    class Receipt : CurrentPriceCatalogue
    {
        public static void PrintReceipt(string path)
        {
            try
            {
                List<string> basketLines = File.ReadAllLines(path).ToList();
                List<CatalogueItem> receiptItem = new();
                foreach (var basketLine in basketLines)
                {
                    foreach (var item in catalogueItems)
                    {
                        if (basketLine == item.Name)
                        {
                            item.Quantity +=1;
                            if (!receiptItem.Contains(item))
                            {
                                receiptItem.Add(item);
                            }
                        }
                    }
                }
                foreach (var item in receiptItem)
                {
                    Console.WriteLine($"{item.Quantity} \t {item.Name} \t\t ${item.Price} \t ${item.OnSalePrice}  ${item.GetEffectivePrice()}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops! something went wrong prining your receipt.\nPlease see a cashier.\n\n" + e.Message);
            }
            finally
            {
                Console.Beep();
            }
        }
    }
}
