using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TaxCalculator.Model;
using TaxCalculator.Utility;

namespace TaxCalculator.Services
{
    public class Calculate : CalculateTax, ICalculate
    {

        public Dictionary<string,double> CalculateTaxAndTotal(IEnumerable<Item> items)
        {
            var dict = new Dictionary<string, double>();

            double rounddOffToNearedt05(Item item) => Math.Ceiling(CalculateTax(item) * 20) / 20;

            try {

                dict.Add("Total tax", items.Select(x => rounddOffToNearedt05(x)).Sum());

                var grossTotal = items.ToList().Select(x => x.TotalPrice + rounddOffToNearedt05(x)).Sum();

                dict.Add("Total amount", grossTotal);

                return dict;                
            }
            catch (Exception ex)
            {
                Logger.Error("Problem calculating tax", ex);
                throw;
            }
        }

        private double CalculateTax(Item item)
        {
            return CalculateGst(item) + CalculateImportDuties(item);
        }
    }
}
