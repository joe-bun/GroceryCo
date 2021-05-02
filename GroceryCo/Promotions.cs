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
                List<string> lines = File.ReadAllLines(path).ToList();
                foreach (string line in lines)
                {
                    string[] entries = line.Split(',');
                    foreach (CatalogueItem item in CatalogueItems)
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
