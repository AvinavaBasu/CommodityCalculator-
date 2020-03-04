using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TaxCalculator.Services;

namespace TaxCalculator.Model.Tests
{
    [TestClass()]
    public class TaxCalculatorTests
    {
        private TaxCalculator _taxCalculator;
        private ICalculate _calculate;
        private Item _item;
        private List<Item> _items;

        [TestInitialize]
        public void Setup()
        {
            _calculate = new Calculate();
            _taxCalculator = new TaxCalculator(_calculate);
        }

        [TestMethod]
        public void ZeroWhenEmpty()
        {
            var taxAndGross = _taxCalculator.CalculateTotal();
            Assert.AreEqual(0, taxAndGross["Total tax"]);
            Assert.AreEqual(0, taxAndGross["Total amount"]);
        }

        [TestMethod]
        public void ShouldReturnSameCostForSingleFoodItem() //no tax
        {
            _item = new Item()
            {
                ItemName = "Sandwich",
                ItemUnitPrice = 7,
                ItemQuantity = 1
            };

            _taxCalculator.Add(_item);

            var taxAndGross = _taxCalculator.CalculateTotal();
            Assert.AreEqual(0, taxAndGross["Total tax"]);
            Assert.AreEqual(7, taxAndGross["Total amount"]);
        }

        [TestMethod]
        public void ShouldReturnSameCostForMultipleFoodItems() //no tax
        {
            _items = new List<Item>()
            {
                new Item(){
                ItemName = "Sandwich",
                ItemUnitPrice = 17,
                ItemQuantity = 1
                },
                new Item(){
                    ItemName = "Burger",
                    ItemUnitPrice = 45,
                    ItemQuantity = 1
                },
            };
            foreach (var item in _items)
            {
                _taxCalculator.Add(item);
            }

            var taxAndGross = _taxCalculator.CalculateTotal();
            Assert.AreEqual(0, taxAndGross["Total tax"]);
            Assert.AreEqual(62, taxAndGross["Total amount"]);
        }

        [TestMethod]
        public void ShouldReturnSameCostForSingleFoodItemOfMultipleQuantities() //no tax
        {
            _item = new Item()
            {
                ItemName = "Sandwich",
                ItemUnitPrice = 7,
                ItemQuantity = 2
            };

            _taxCalculator.Add(_item);


            var taxAndGross = _taxCalculator.CalculateTotal();
            Assert.AreEqual(0, taxAndGross["Total tax"]);
            Assert.AreEqual(14, taxAndGross["Total amount"]);
        }

        [TestMethod]
        public void ShouldReturnSameCostForSinglNonFoodItem() //7% gst
        {
            _item = new Item()
            {
                ItemName = "Book",
                ItemUnitPrice = 17,
                ItemQuantity = 1
            };

            _taxCalculator.Add(_item);


            var taxAndGross = _taxCalculator.CalculateTotal();
            Assert.AreEqual(1.2, taxAndGross["Total tax"]);
            Assert.AreEqual(18.2, taxAndGross["Total amount"]);
        }

        [TestMethod]
        public void ShouldReturnSameCostForFoodAndNonFoodItems() //4.35 rounding off tax
        {
            _items = new List<Item>()
            {
                new Item(){
                    ItemName = "Sandwich",
                    ItemUnitPrice = 19,
                    ItemQuantity = 1
                },
                new Item(){
                    ItemName = "Book",
                    ItemUnitPrice = 17,
                    ItemQuantity = 1
                },
                new Item(){
                    ItemName = "Cap",
                    ItemUnitPrice = 45,
                    ItemQuantity = 1
                }
            };
            foreach (var item in _items)
            {
                _taxCalculator.Add(item);
            }

            var taxAndGross = _taxCalculator.CalculateTotal();
            Assert.AreEqual(4.35, taxAndGross["Total tax"]);
            Assert.AreEqual(85.35, taxAndGross["Total amount"]);
        }


        [TestMethod]
        public void ShouldReturnSameCostForImportedAndNonImportedItems() //no tax
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
            foreach (var item in _items)
            {
                _taxCalculator.Add(item);
            }

            var taxAndGross = _taxCalculator.CalculateTotal();
            Assert.AreEqual(120.85, taxAndGross["Total tax"]);
            Assert.AreEqual(1053.85, taxAndGross["Total amount"]);
        }
    }
}