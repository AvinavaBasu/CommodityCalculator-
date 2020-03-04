using System.Collections.Generic;
using TaxCalculator.Model;

namespace TaxCalculator.Services
{
    public interface ICalculate
    {
        Dictionary<string,double> CalculateTaxAndTotal(IEnumerable<Item> items);
    }

}
