using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GroceryCo
{
    public class CurrentPriceCatalogue
    {
        private static List<CatalogueItem> catalogueItems = new();

        public static List<CatalogueItem> CatalogueItems { get => catalogueItems; set => catalogueItems = value; }

        public static void BuildCurrentPriceCatalogue(string catalogueFilePath)
        {
            try
            {
                List<string> lines = File.ReadAllLines(catalogueFilePath).ToList();
                foreach (var line in lines)
                {
                    string[] entries = line.Split(',');
                    CatalogueItem newItem = new(entries[0], entries[1]);
                    CatalogueItems.Add(newItem);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops! please check the catalogue file for errors.\n\n" + e.Message);
            }
        }
    }
}
