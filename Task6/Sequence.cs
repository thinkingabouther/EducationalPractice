using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Task6
{
    public class TooBigNumbersException : Exception
    {
        public TooBigNumbersException(string expression) : base(expression)
        {
            
        }
    }

    public class WrongSequenceLengthException : Exception
    {
        public WrongSequenceLengthException(int length) : base(ModifyDefaultMessage(length))
        {
            
        }

        private static string ModifyDefaultMessage(int length)
        {
            return $"{length} is inappropriate for length attribute. Try length more than 3";
        }

    }

    public class WrongSequenceMemberIndexException : Exception
    {
        public WrongSequenceMemberIndexException(int index) : base(ModifyDefaultMessage(index))
        {
            
        }

        private static string ModifyDefaultMessage(int index)
        {
            return $"Index {index} is out of sequence. Try creating a new one";
        }
    }
    [ExcludeFromCodeCoverage]
    internal class SequenceEnumerator : IEnumerator
    {
        private readonly Sequence _currentSequence;
        private int _enumeratingPosition = -1;
        public SequenceEnumerator(Sequence currentSequence)
        {
            this._currentSequence = currentSequence;
        }

        public bool MoveNext()
        {
            if (_enumeratingPosition < _currentSequence.Length - 1)
            {
                _enumeratingPosition++;
                return true;
            }

            return false;
        }
        public void Reset()
        {
            _enumeratingPosition = -1;
        }

        public object Current
        {
            get
            {
                if (_enumeratingPosition == -1 | _enumeratingPosition >= _currentSequence.Length)
                {
                    throw new WrongSequenceMemberIndexException(_enumeratingPosition);
                }
                return _currentSequence[_enumeratingPosition];
            }
            
        }
    }

    public class SequenceMember 
    {
        private readonly int _value;
        public int Index;

        public SequenceMember(int value, int index=0)
        {
            _value = value;
            Index = index;
        }

        public override string ToString()
        {
            return $"The {Index+1} element of the sequence is {_value}";
        }
        [ExcludeFromCodeCoverage]
        public static SequenceMember operator +(SequenceMember a, SequenceMember b)
        {

            try
            {
                return new SequenceMember(checked(a._value + b._value));
            }
            catch (OverflowException)
            {
                throw new TooBigNumbersException($"Operation {a._value} + {b._value} causes overflow of the integer type");
            }
        }

        public static SequenceMember operator *(int constant, SequenceMember a)
        {
            try
            {
                return new SequenceMember(checked(a._value * constant), a.Index);
            }
            catch (OverflowException)
            {
                throw new TooBigNumbersException($"Operation {constant} * {a._value} causes overflow of the integer type");

            }
        }

        public static bool operator >=(SequenceMember a, SequenceMember b)
        {
            return a._value >= b._value;
        }
        [ExcludeFromCodeCoverage]
        public static bool operator <=(SequenceMember a, SequenceMember b)
        {
            return a._value <= b._value;
        }
        
    }

    public class Sequence : IEnumerable
    {
        private readonly List<SequenceMember> _sequenceMembers = new List<SequenceMember>();
        public int length;
        //public BigInteger RecursionDepth = 0;
        public Sequence(int firstMember, int secondMember, int thirdMember, int numberOfMembers)
        {
            Length = numberOfMembers;
            _sequenceMembers.Add(new SequenceMember(firstMember, 0));
            _sequenceMembers.Add(new SequenceMember(secondMember, 1));
            _sequenceMembers.Add(new SequenceMember(thirdMember, 2));
            GenerateAllMembers();
        }

        public int Length
        {
            get { return length; }
            set
            {
                if (value < 3) throw new WrongSequenceLengthException(value);
                length = value;
            }
        }

        private SequenceMember GenerateMember(int numberOfMember)
        {
            //this.RecursionDepth++;
            if (numberOfMember < 3)
            {
                return _sequenceMembers[numberOfMember];
            }
            SequenceMember currentMember = 13 * GenerateMember(numberOfMember - 1) +
                                           10 * GenerateMember(numberOfMember - 2) +
                                           GenerateMember(numberOfMember - 3);

            currentMember.Index = numberOfMember;
            return currentMember;
            
        }

        private void GenerateAllMembers()
        {
            for (int i = 3; i < Length; i++)
            {
                //Thread thread = new Thread(new ThreadStart(delegate { GenerateMember(i); }), 5);
                //thread.Start();
                _sequenceMembers.Add(GenerateMember(i));
                //Console.WriteLine($"for member - {i} number of calls is {RecursionDepth}");
                //RecursionDepth = new BigInteger(0);
            }
        }

        public SequenceMember this[int index]
        {
            get
            {
                if (index < 0 | index >= Length) throw new WrongSequenceMemberIndexException(index);
                return _sequenceMembers[index];
            }
        }

        public bool IsRisingSequenceEvenElements()
        {
            for (int i = 1; i < Length-2; i = i + 2)
            {
                if (this[i] >= this[i + 2]) return false;
            }

            return true;
        }

        public IEnumerator GetEnumerator()
        {
            return new SequenceEnumerator(this);
        }
    }
}