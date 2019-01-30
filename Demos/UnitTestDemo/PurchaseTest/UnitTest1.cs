using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestDemo;

namespace PurchaseTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PurchaseA_NoDiscount()
        {

            int motherBoardPC = 4;
            int cpuPC = 1;
            int winchesterPC = 4;

            Purchase purchase = new Purchase();
            int result = purchase.PurchaseA(motherBoardPC, cpuPC, winchesterPC);
            int expected = 4 * 100 + 1 * 120 + 4 * 80;

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void PurchaseB_NoDiscount()
        {

            int motherBoardPC = 4;
            int cpuPC = 1;
            int winchesterPC = 4;
            double increase = 1.1;

            Purchase purchase = new Purchase();
            int result = purchase.PurchaseB(motherBoardPC, cpuPC, winchesterPC);
            int expected = (int)(4 * (100 * increase) + 1 * (120 * increase) + 4 * (80 * increase));

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void PurchaseC_NoDiscount()
        {

            int motherBoardPC = 4;
            int cpuPC = 1;
            int winchesterPC = 4;
            double increase = 1.3;

            Purchase purchase = new Purchase();
            int result = purchase.PurchaseC(motherBoardPC, cpuPC, winchesterPC);
            int expected = (int)(4 * (100 * increase) + 1 * (120 * increase) + 4 * (80 * increase));

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void Discount_None()
        {
            Purchase purchase = new Purchase();

            int result = purchase.Discount(1000, 30);
            int expected = 0;

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void Discount_2()
        {
            Purchase purchase = new Purchase();

            double discount = 1.02;
            int result = purchase.Discount(1000, 31);
            int expected = (int)(1000 * discount);

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void Discount_3()
        {
            Purchase purchase = new Purchase();

            double discount = 1.03;
            int result = purchase.Discount(1000, 51);
            int expected = (int)(1000 * discount);

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void Discount_5()
        {
            Purchase purchase = new Purchase();

            double discount = 1.05;
            int result = purchase.Discount(10100, 11);
            int expected = (int)(10100 * discount);

            Assert.AreEqual(result, expected);
        }
    }
}
