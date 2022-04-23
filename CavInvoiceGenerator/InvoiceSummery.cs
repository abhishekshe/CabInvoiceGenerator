using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
   
    public class InvoiceSummery
    {
        private int numberOfRides;
        private double totalFare;
        private double averageFare;

      
        public InvoiceSummery(int numberOfRides, double totalFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = totalFare / numberOfRides;
        }
      
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is InvoiceSummery))
            {
                return false;
            }
            InvoiceSummery imputedObject = (InvoiceSummery)obj;
            return this.numberOfRides == imputedObject.numberOfRides && this.totalFare == imputedObject.totalFare && this.averageFare == imputedObject.averageFare;
        }
    }
}