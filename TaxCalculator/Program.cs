using System.Collections.Generic;
using Autofac;
using TaxCalculator.Model;
using TaxCalculator.Services;

namespace TaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {

            var builder = new ContainerBuilder();
            builder.RegisterType<Calculate>().As<ICalculate>();
            builder.RegisterType<BootStrapper>().AsSelf();
            var container = builder.Build();
            var items = container.Resolve<BootStrapper>().ItemInformations;
            var gross = container.Resolve<ICalculate>().CalculateTaxAndTotal(items);

            foreach (var item in gross)
            {
                System.Console.WriteLine(""+item.Key+"= "+item.Value);
            }
            System.Console.ReadKey();
        }
    }
}
