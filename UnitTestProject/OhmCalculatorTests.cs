using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfAppTK;

namespace UnitTestProject
{
    [TestClass]
    public class OhmCalculatorTests
    {
        private readonly OhmCalculator _calc = new OhmCalculator();

        [TestMethod]
        public void CalculateCurrent_ValidValues_ReturnsCorrectResult()
        {
            double result = _calc.CalculateCurrent(voltage: 12, resistance: 4);
            Assert.AreEqual(3.0, result, delta: 1e-6);
        }

        [TestMethod]
        public void CalculateCurrent_ZeroResistance_ThrowsDivideByZero()
        {
            Assert.ThrowsException<DivideByZeroException>(() =>
                _calc.CalculateCurrent(voltage: 12, resistance: 0));
        }

        [TestMethod]
        public void CalculateVoltage_ValidValues_ReturnsCorrectResult()
        {
            double result = _calc.CalculateVoltage(current: 3, resistance: 4);
            Assert.AreEqual(12.0, result, delta: 1e-6);
        }

        [TestMethod]
        public void CalculateResistance_ValidValues_ReturnsCorrectResult()
        {
            double result = _calc.CalculateResistance(voltage: 12, current: 3);
            Assert.AreEqual(4.0, result, delta: 1e-6);
        }

        [TestMethod]
        public void CalculateResistance_ZeroCurrent_ThrowsDivideByZero()
        {
            Assert.ThrowsException<DivideByZeroException>(() =>
                _calc.CalculateResistance(voltage: 12, current: 0));
        }

        [TestMethod]
        public void Calculate_InvalidType_ThrowsArgumentOutOfRange()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                _calc.Calculate((CalculationType)99, 1, 1));
        }

        [TestMethod]
        public void CalculateCurrent_ZeroVoltage_ReturnsZero()
        {
            double result = _calc.CalculateCurrent(voltage: 0, resistance: 10);
            Assert.AreEqual(0.0, result, delta: 1e-6);
        }

        [TestMethod]
        public void CalculateVoltage_ZeroCurrent_ReturnsZero()
        {
            double result = _calc.CalculateVoltage(current: 0, resistance: 10);
            Assert.AreEqual(0.0, result, delta: 1e-6);
        }

        [TestMethod]
        public void CalculateResistance_ZeroVoltage_ReturnsZero()
        {
            double result = _calc.CalculateResistance(voltage: 0, current: 5);
            Assert.AreEqual(0.0, result, delta: 1e-6);
        }

        [TestMethod]
        public void CalculateCurrent_NegativeVoltage_ReturnsNegative()
        {
            double result = _calc.CalculateCurrent(voltage: -10, resistance: 2);
            Assert.AreEqual(-5.0, result, delta: 1e-6);
        }
    }
}