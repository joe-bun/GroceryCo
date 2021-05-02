using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GroceryCo
{
    class Checkout
    {
        static List<CatalogueItem> catalogueItems = new List<CatalogueItem>();
        static void Main(string[] args)
        {
            
            BuildCatalogue(@"data\catalogue.txt");
            ApplyPromotions(@"data\promotion.txt");
            PrintReceipt(@"data\basket.txt");
        }
        public static void BuildCatalogue(string path)
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
                        if (entries[0] == item.name)
                        {
                            item.onSale = true;
                            item.setOnSalePrice(entries[1]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops! please check the promotion file for errors.\n\n" + e.Message);
            }
        }
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
                        if (basketLine == item.name)
                        {
                            item.quantity += 1;
                            if (!receiptItem.Contains(item))
                                receiptItem.Add(item);
                        }
                    }
                }
                foreach (var item in receiptItem)
                {
                    Console.WriteLine($"{item.quantity} \t {item.name} \t\t ${item.price} \t ${item.onSalePrice}  ${item.getEffectivePrice()}");
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
