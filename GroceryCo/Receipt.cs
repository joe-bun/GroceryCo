using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GroceryCo
{
    class Receipt : Basket
    {        
        public static void PrintReceipt(string basketFilePath)
        {           
            try
            {
                ScanBasketItems(basketFilePath);
                BuildFormattedReceipt();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Oops! something went wrong printing your receipt.\nPlease see a cashier.\n\n{e.Message}");
            }
            finally
            {
                Console.Beep();
            }
        }
        static void BuildFormattedReceipt()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(" Quantity \t Item Name \t\t Item Price \t\t *Promotional Price* \t Price Charged ");
            Console.ResetColor();
            foreach (CatalogueItem item in ReceiptItems)
            {
                Console.WriteLine(" {0} \t\t {1} \t\t\t ${2} \t\t\t {3} \t\t\t ${4}",item.Quantity,item.Name,item.Price,( item.IsOnSale ? "$"+item.OnSalePrice : ""),item.GetEffectivePrice());
            }
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("");
            Console.WriteLine($"\t\t\t\t\t Total price payable is ${Checkout.CalculateTotalPrice()} ");
            Console.ResetColor();
        }
           
    }
}
