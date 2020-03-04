using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Model;

namespace TaxCalculator.Services
{
    public interface ICalculateGst
    {
        double CalculateGst(Item item);
    }
}
