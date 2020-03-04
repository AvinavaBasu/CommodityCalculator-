using System.Linq;

namespace TaxCalculator.Model
{
    public class Item
    {
        public string ItemName { get; set; }
        public double ItemUnitPrice { get; set; }
        public int ItemQuantity { get; set; }
        public bool IsImported => ItemName.ToLower().Contains("imported") ? true : false;
        public string GetItemName => IsImported ? string.Concat(ItemName.Skip(9)).ToLower() : ItemName.ToLower();
        public double TotalPrice => ItemQuantity * ItemUnitPrice;
    }
}
