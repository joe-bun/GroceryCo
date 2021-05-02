using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GroceryCo
{
    public class CurrentPriceCatalogue
    {
        public static List<CatalogueItem> catalogueItems = new();
        public static void BuildCurrentPriceCatalogue(string path)
        {
            try
            {
                List<string> lines = File.ReadAllLines(path).ToList();
                foreach (var line in lines)
                {
                    string[] entries = line.Split(',');
                    CatalogueItem newItem = new(entries[0], entries[1]);
                    catalogueItems.Add(newItem);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops! please check the catalogue file for errors.\n\n" + e.Message);
            }
        }
    }
}
