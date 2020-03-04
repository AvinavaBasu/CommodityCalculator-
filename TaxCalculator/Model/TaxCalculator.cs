using System.Collections.Generic;
using TaxCalculator.Services;

namespace TaxCalculator.Model
{
    public class TaxCalculator
    {
        private readonly ICalculate _calculate;
        private readonly List<Item> _items;

        public IEnumerable<Item> Items => _items;

        public TaxCalculator(ICalculate calculate)
        {
            _items =new  List <Item>();
            _calculate = calculate;
        }

        public void Add(Item orderItem)
        {
            _items.Add(orderItem);
        }

        public Dictionary<string,double> CalculateTotal()
        {   
            var taxAndGross = _calculate.CalculateTaxAndTotal(_items);   
            return taxAndGross;
        }

        
    }
}
