using System;
namespace CabInvoiceGenerator
{
    
    public class Program
    {
       
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Cab Invoice Program");
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double fare = invoiceGenerator.CalculateFare(2.0, 5);
            Console.WriteLine($"Fare: {fare}");
        }
    }
}