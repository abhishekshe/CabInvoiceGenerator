using NUnit.Framework;
using CabInvoiceGenerator;

namespace Cab_Invoice_TDD
{
   
   
    public class Tests
    {
       
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            double distance = 2.0;
            int time = 5;

           
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;
            Assert.AreEqual(expected, fare);
        }
    }
}