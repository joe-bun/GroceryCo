namespace GroceryCo
{
    class Program
    {
        static void Main(string[] args)
        {
            Checkout();
        }
        public static void Checkout()
        {
            CurrentPriceCatalogue.BuildCurrentPriceCatalogue(@"data\catalogue.txt");
            Promotions.ApplyPromotions(@"data\promotion.txt");
            Receipt.PrintReceipt(@"data\basket.txt");
        }
    }
}
