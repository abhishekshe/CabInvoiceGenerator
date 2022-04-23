
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
namespace CabInvoiceGenerator
{
   
   
    public class InvoiceGenerator
    {
        
        private RideRepository rideRepository;
        RideType rideType;
        
        private readonly double MINIMUM_COST_PER_KM;
        private readonly int COST_PER_TIME;
        private readonly double MINIMUM_FARE;

        
        public InvoiceGenerator(RideType rideType)
        {
            this.rideRepository = new RideRepository();
            this.rideType = rideType;
            try
            {
                if (this.rideType.Equals(RideType.NORMAL))
                {
                    this.MINIMUM_COST_PER_KM = 10;
                    this.COST_PER_TIME = 1;
                    this.MINIMUM_FARE = 5;
                }
                if (this.rideType.Equals(RideType.PREMIUM))
                {
                    this.MINIMUM_COST_PER_KM = 15;
                    this.COST_PER_TIME = 2;
                    this.MINIMUM_FARE = 20;
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDETYPE, "invalid ride type");
            }


        }

       
        public double CalculateFare(double distance, int time)
        {
            double totalFare = 0;
            try
            {
                totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
            }
            catch (CabInvoiceException)
            {
                if (distance <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid Distance");
                }
                if (time <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid Time");
                }
            }
            return Math.Max(totalFare, MINIMUM_FARE);
        }
  
        public InvoiceSummery CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            
            try
            {
               
                foreach (Ride ride in rides)
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);
                }
            }
         
            catch (CabInvoiceException)
            {
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "no rides found");
                }
            }
            
            return new InvoiceSummery(rides.Length, totalFare);
        }
      
        public void AddRides(string userId, Ride[] rides)
        {
            try
            {
                rideRepository.AddRide(userId, rides);
            }
            catch (CabInvoiceException)
            {
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Null rides");
                }
            }
        }
       
        public InvoiceSummery GetInvoiceSummary(string userId)
        {
            try
            {
                return this.CalculateFare(rideRepository.GetRides(userId));
            }
            catch
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid user id");
            }
        }
    }

}