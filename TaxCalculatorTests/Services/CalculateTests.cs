using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxCalculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Model;

namespace TaxCalculator.Services.Tests
{
    [TestClass()]
    public class CalculateTests
    {

        private IEnumerable<Item> _items;
        private Calculate _calculate;
        private Item _item;
        private CalculateTax _calculateTax;

        [TestInitialize]
        public void Setup()
        {
            _items = new List<Item>();
            _calculate = new Calculate();
            _item = new Item();
            _calculateTax = new CalculateTax();
        }

        [TestMethod()]
        public void CalculateTaxAndTotalTest()
        {
            _items = new List<Item>()
            {
                new Item(){
                    ItemName = "Imported Sandwich",
                    ItemUnitPrice = 75,
                    ItemQuantity = 2
                },
                new Item(){
                    ItemName = "Imported Book",
                    ItemUnitPrice = 280,
                    ItemQuantity = 1
                },
                new Item(){
                    ItemName = "Imported Cap",
                    ItemUnitPrice = 115,
                    ItemQuantity = 2
                },
                new Item(){
                    ItemName = "Tee-shirt",
                    ItemUnitPrice = 273,
                    ItemQuantity = 1
                }
            };

           var taxAndGross = _calculate.CalculateTaxAndTotal(_items);
            Assert.AreEqual(120.85, taxAndGross["Total tax"]);
            Assert.AreEqual(1053.85, taxAndGross["Total amount"]);
        }

        [TestMethod]
        public void ShouldGetZeroGstIfFoodItem()
        {
            _item = new Item
            {
                ItemName = "Sandwich",
            };

            var gstValue = _calculateTax.CalculateGst(_item);

            Assert.AreEqual(0, gstValue);
        }

        [TestMethod]
        public void ShouldGet7PercentGstIfNonFoodItem()
        {
            _item = new Item
            {
                ItemName = "Book",
                ItemUnitPrice=17,
                ItemQuantity=1
            };

            var gstValue = _calculateTax.CalculateGst(_item);

            Assert.AreEqual(1.19, gstValue);
        }

        [TestMethod]
        public void ShouldGetZeroImportDutiesIfNotImported()
        {
            _item = new Item
            {
                ItemName = "Sandwich",
            };

            var gstValue = _calculateTax.CalculateImportDuties(_item);

            Assert.AreEqual(0, gstValue);
        }

        [TestMethod]
        public void ShouldGet10PercentGstIfImported()
        {
            _item = new Item
            {
                ItemName = "Imported Book",
                ItemUnitPrice = 280,
                ItemQuantity = 1
            };

            var gstValue = _calculateTax.CalculateImportDuties(_item);

            Assert.AreEqual(28, gstValue);
        }
    }
}