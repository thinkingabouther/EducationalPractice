using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Task6
{
    internal static class MainProgram
    {
        public static void Main(string[] args)
        {
            Sequence sequence = new Sequence(1, -2, -6, 5);
            foreach (SequenceMember sequenceMember in sequence)
            {
                Console.WriteLine(sequenceMember);
            }
            Console.WriteLine(sequence.IsRisingSequenceEvenElements()
                ? "Even elements of the sequence form a rising subsequence"
                : "Event element of the sequence do not form a rising subsequence");
            
        }
    }

    internal class SequenceMember 
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
         
        public static SequenceMember operator +(SequenceMember a, SequenceMember b)
        {
            return new SequenceMember(a._value + b._value);
        }

        public static SequenceMember operator *(int constant, SequenceMember a)
        {
            return new SequenceMember(a._value * constant, a.Index);
        }

        public static bool operator >=(SequenceMember a, SequenceMember b)
        {
            return a._value >= b._value;
        }
        
        public static bool operator <=(SequenceMember a, SequenceMember b)
        {
            return a._value <= b._value;
        }
        
    }
    internal class Sequence : IEnumerable
    {
        private readonly List<SequenceMember> _sequenceMembers = new List<SequenceMember>();
        public readonly int Length;
        public Sequence(int firstMember, int secondMember, int thirdMember, int numberOfMembers)
        {
            Length = numberOfMembers;
            _sequenceMembers.Add(new SequenceMember(firstMember, 0));
            _sequenceMembers.Add(new SequenceMember(secondMember, 1));
            _sequenceMembers.Add(new SequenceMember(thirdMember, 2));
            GenerateMember(numberOfMembers - 1);
        }

        private SequenceMember GenerateMember(int numberOfMember)
        {
            if (numberOfMember < 3)
            {
                return _sequenceMembers[numberOfMember];
            }

            SequenceMember currentMember = 13 * GenerateMember(numberOfMember - 1) +
                                               10 * GenerateMember(numberOfMember - 2) +
                                               GenerateMember(numberOfMember - 3);
            _sequenceMembers.Add(currentMember);
            _sequenceMembers[numberOfMember].Index = numberOfMember;
            return _sequenceMembers[numberOfMember];
        }

        public SequenceMember this[int index]
        {
            get
            {
                if (index < 0 | index >= Length) throw new WrongSequenceMemberIndex(index);
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
                    throw new WrongSequenceMemberIndex(_enumeratingPosition);
                }
                return _currentSequence[_enumeratingPosition];
            }
            
        }
    }

    internal class WrongSequenceMemberIndex : Exception
    {
        public WrongSequenceMemberIndex(int index) : base(ModifyDefaultMessage(index))
        {
            
        }

        private static string ModifyDefaultMessage(int index)
        {
            return $"Index {index} is out of sequence. Try creating a new one";
        }
    }
}