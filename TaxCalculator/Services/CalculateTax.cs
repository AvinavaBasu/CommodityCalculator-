using System;
using System.Collections.Generic;
using System.Linq;
using TaxCalculator.Model;

namespace TaxCalculator.Services
{
    public class CalculateTax : ICalculateTax
    {
        public static readonly List<string> FoodAndMedList = new List<string> { "sandwich", "burger", "crocin", "paracetamol" };   
        //calculateGst
        public double CalculateGst(Item item)
        {
            double gstdouble = 0;
            if (!FoodAndMedList.Contains(item.GetItemName))
            {
                gstdouble = item.TotalPrice * (double)TaxEnums.Gst/100;
            }
            return gstdouble;
        }

        //calculateImportDuties
        public double CalculateImportDuties(Item item)
        {
            double importDuties = 0;
            if (item.IsImported)
            {
                importDuties = item.TotalPrice * ((double)TaxEnums.ImportDuties / 100);
            }
            return importDuties;
        }
    }
}
