using System;

namespace WpfAppTK
{
    public enum CalculationType
    {
        Current,
        Voltage,
        Resistance
    }

    public class OhmCalculator
    {
        /// <summary>Вычислить силу тока I = V / R</summary>
        public double CalculateCurrent(double voltage, double resistance)
        {
            if (resistance == 0)
                throw new DivideByZeroException("Сопротивление не может быть равно нулю.");
            return voltage / resistance;
        }

        /// <summary>Вычислить напряжение V = I * R</summary>
        public double CalculateVoltage(double current, double resistance)
        {
            return current * resistance;
        }

        /// <summary>Вычислить сопротивление R = V / I</summary>
        public double CalculateResistance(double voltage, double current)
        {
            if (current == 0)
                throw new DivideByZeroException("Сила тока не может быть равна нулю.");
            return voltage / current;
        }

        public double Calculate(CalculationType type, double param1, double param2)
        {
            switch (type)
            {
                case CalculationType.Current: return CalculateCurrent(param1, param2);
                case CalculationType.Voltage: return CalculateVoltage(param1, param2);
                case CalculationType.Resistance: return CalculateResistance(param1, param2);
                default: throw new ArgumentOutOfRangeException(nameof(type));
            }
        }
    }
}