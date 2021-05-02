namespace GroceryCo
{
    class Program
    {
        static void Main(string[] args)
        {            
            Checkout.ProcessCheckout(@"data\basket.txt");
        }        
    }
}
