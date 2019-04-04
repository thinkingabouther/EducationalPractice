using System;
using Utilities;

namespace Task3
{
    internal static class MainProgram
    {
        public static void Main(string[] args)
        {
            double answer = new PointU(
                ConsoleInputParse.Double(
                    "Input X value", "Unable to cast to double"),
                ConsoleInputParse.Double(
                    "Input Y value", "Unable to cast to double")).GetUValue();
            Console.WriteLine($"The answer is {answer}");            
        }
    }

    public class PointU
    {
        private readonly double _x;
        private readonly double _y;
        public readonly bool IsInAreaD;
        
        public PointU(double x, double y)
        {
            _x = x;
            _y = y;
            IsInAreaD = CheckIsInAreaD();
        }

        bool CheckIsInAreaD()
        {
            return _y >= 0 & (_x <= 0 & _x * _x + _y * _y <= 1 | _x >= 0 & _x * _x + _y * _y >= 0.09 & _x * _x + _y * _y <= 1);
        }

        public double GetUValue()
        {
            if (IsInAreaD) return _x * _x - 1;
            return Math.Sqrt(Math.Abs(_x - 1));
        }
    }


}