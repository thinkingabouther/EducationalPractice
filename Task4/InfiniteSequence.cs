using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Task4
{
    public class TooBigAccuracyException : Exception
    {
        public TooBigAccuracyException(double eps) : base(ModifyExceptionMessage(eps))
        {
                
        }

        private static string ModifyExceptionMessage(double eps)
        {
            return $"The accuracy given ({eps}) is too small. Try giving bigger number";
        }
    }

    public class ElementOfSequence
    {
        private readonly int _number;
        private readonly double _value;
        public ElementOfSequence(int number, double value)
        {
            _number = number;
            _value = value;
        }

        public override string ToString()
        {
            return $"The element number {_number} has value: {_value} ";
        }

        public static double operator -(ElementOfSequence a, ElementOfSequence b)
        {
            return a._value - b._value;
        }
        [ExcludeFromCodeCoverage]
        public static implicit operator double(ElementOfSequence a)
        {
            return a._value;
        }

    }

    public class InfiniteSequence : IEnumerable
    {
        private readonly List<ElementOfSequence> _sumMembers;
        
        private double _eps;

        public InfiniteSequence(double eps)
        {
            _sumMembers = new List<ElementOfSequence>();
            Eps = eps;
            GetMembers();
        }

        public double Eps
        {
            set
            {
                if (value < 0.0000000000001)
                {
                    throw new TooBigAccuracyException(value);
                }
                _eps = value;
            }
        }

        private void GetMembers()
        {
            ElementOfSequence previousMember = new ElementOfSequence(1, GetMemberByNum(1));
            ElementOfSequence currentMember = new ElementOfSequence(2, GetMemberByNum(2));
            _sumMembers.Add(previousMember);
            var currentNumber = 3;
            while (Math.Abs(previousMember - currentMember) >= _eps)
            {
                _sumMembers.Add(currentMember);
                previousMember = currentMember;
                currentMember = new ElementOfSequence(currentNumber, GetMemberByNum(currentNumber));
                currentNumber++;
            }
        }

        private double GetMemberByNum(int number)
        {
            return 1 / (double) (number * number);
        }

        public IEnumerator GetEnumerator()
        {
            return _sumMembers.GetEnumerator();
        }

        
    }
}