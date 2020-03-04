using System;
using System.Collections.Generic;
using TaxCalculator.Model;

namespace TaxCalculator
{
    public class BootStrapper
    {
        public List<Item> ItemInformations
        {
            get
            {
                var listOfItems = new List<Item>();
                var Item = new Item();
                try
                {
                    Console.WriteLine("Please insert the number of Items for tax calculation");
                    var numberOfItems = Convert.ToInt32(Console.ReadLine());
                    for (int i = 1; i <= numberOfItems; i++)
                    {
                        Console.WriteLine("Insert the elemet at {0} position", i);
                        Console.WriteLine("Item name");
                        var itemName = Console.ReadLine();
                        Console.WriteLine("Item Quantity");
                        var itemQuantity = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Item Unit Price");
                        var itemUnitPrice = Convert.ToInt32(Console.ReadLine());

                        listOfItems.Add(new Item { ItemName = itemName, ItemQuantity = itemQuantity, ItemUnitPrice = itemUnitPrice });
                    }
                }
                catch (Exception ex)
                {

                    Utility.Logger.Error("Please check the input stream", ex);
                }
                return listOfItems;
            }
        }
    }
}
