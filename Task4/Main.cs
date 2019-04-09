using System;
using System.Collections;
using System.Collections.Generic;
using Utilities;

namespace Task4
{
    internal static class MainProgram
    {
        public static void Main(string[] args)
        {
            double eps = ConsoleInputParse.Double("Input the accuracy of calculations (epsilon)",
                "Incorrect input, should be double");
            InfiniteSum sum = new InfiniteSum(eps);
            foreach (var elementOfSum in sum)
            {
                Console.WriteLine(elementOfSum.ToString());
            }
        }
    }

    class ElementOfSum
    {
        private readonly int _number;
        private readonly double _value;
        public ElementOfSum(int number, double value)
        {
            _number = number;
            _value = value;
        }

        public override string ToString()
        {
            return $"The element number {_number} has value: {_value} ";
        }

        public static double operator -(ElementOfSum a, ElementOfSum b)
        {
            return a._value - b._value;
        }
    }
    class InfiniteSum : IEnumerable
    {
        private readonly List<ElementOfSum> _sumMembers;
        private readonly double _eps;

        public InfiniteSum(double eps)
        {
            _sumMembers = new List<ElementOfSum>();
            _eps = eps;
            GetMembers();
        }

        private void GetMembers()
        {
            ElementOfSum previousMember = new ElementOfSum(1,GetMemberByNum(1)); 
            ElementOfSum currentMember = new ElementOfSum(2,GetMemberByNum(2)); 
            _sumMembers.Add(previousMember);
            var currentNumber = 3;
            while (Math.Abs(previousMember - currentMember) >= _eps) 
            {
                _sumMembers.Add(currentMember);
                previousMember = currentMember;
                currentMember = new ElementOfSum(currentNumber, GetMemberByNum(currentNumber));
                currentNumber++;
            }
        }

        private double GetMemberByNum(int number)
        {
            return 1 / (double)(number * number);
        }

        public IEnumerator GetEnumerator()
        {
            return _sumMembers.GetEnumerator();
        }
    }
}