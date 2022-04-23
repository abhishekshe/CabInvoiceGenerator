using NUnit.Framework;
using CabInvoiceGenerator;
using System.Net.Http.Headers;
namespace Cab_Invoice_TDD
{
   

    
    public class Tests
    {
       
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = 2.0;
            int time = 5;

            
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 40;
            Assert.AreEqual(expected, fare);
        }
      
        [Test]
        public void GivenMultipleRidesShouldReturnInvoiceSummary()
        {
            
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            
            InvoiceSummery summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummery expectedSummary = new InvoiceSummery(2, 60.0);

            
            Assert.AreEqual(expectedSummary, summary);
        }
       
        [Test]
        public void GivenMultipleRidesShouldReturnInvoiceSummarywithAverageFare()
        {
             
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };


            InvoiceSummery summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummery expectedSummary = new InvoiceSummery(2, 60.0);

            Assert.AreEqual(expectedSummary, summary);
        }
     
    
        [Test]
        public void GivenRidesForDifferentUsersShouldReturnInvoiceSummary()
        {
            
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            string userId = "001";
            invoiceGenerator.AddRides(userId, rides);
            string userIdForSecondUser = "002";
            Ride[] ridesForSecondUser = { new Ride(3.0, 10), new Ride(1.0, 2) };
            invoiceGenerator.AddRides(userIdForSecondUser, ridesForSecondUser);

            InvoiceSummery summary = invoiceGenerator.GetInvoiceSummary(userId);
            InvoiceSummery expectedSummary = new InvoiceSummery(2, 30.0);

            Assert.AreEqual(expectedSummary, summary);
        }
    }
}