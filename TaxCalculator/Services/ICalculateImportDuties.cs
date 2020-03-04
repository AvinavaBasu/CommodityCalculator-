using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Model;

namespace TaxCalculator.Services
{
    public interface ICalculateImportDuties
    {
        double CalculateImportDuties(Item item);
    }
}
