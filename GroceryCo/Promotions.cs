using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GroceryCo
{
    public class Promotions : CurrentPriceCatalogue
    {
        public static void ApplyPromotions(string path)
        {
            try
            {
                List<string> promotionLines = File.ReadAllLines(path).ToList();
                foreach (var promotionLine in promotionLines)
                {
                    string[] entries = promotionLine.Split(',');
                    foreach (var item in catalogueItems)
                    {
                        if (entries[0] == item.Name)
                        {
                            item.IsOnSale = true;
                            item.OnSalePrice = Convert.ToDecimal(entries[1]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops! please check the promotion file for errors.\n\n" + e.Message);
            }
        }
    }
}
