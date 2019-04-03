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

    class PointU
    {
        private readonly double x;
        private readonly double y;
        private bool isInAreaD;
        
        public PointU(double x, double y)
        {
            this.x = x;
            this.y = y;
            isInAreaD = IsInAreaD();
        }

        bool IsInAreaD()
        {
            return y >= 0 & (x <= 0 & x * x + y * y <= 1 | x >= 0 & x * x + y * y >= 0.09 & x * x + y * y <= 1);
        }

        public double GetUValue()
        {
            if (isInAreaD) return x * x - 1;
            return Math.Sqrt(Math.Abs(x - 1));
        }
    }


}