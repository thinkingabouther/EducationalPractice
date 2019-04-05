using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Task6
{
    internal static class MainProgram
    {
        public static void Main(string[] args)
        {
            Sequence sequence = new Sequence(1, -2, -6, 5);
            for (int i = 0; i < sequence.Length; i++)
            {
                Console.WriteLine(sequence[i]);
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
    internal class Sequence
    {
        private readonly SequenceMember[] _sequenceMembers;
        public readonly int Length;
        public Sequence(int firstMember, int secondMember, int thirdMember, int numberOfMembers)
        {
            _sequenceMembers = new SequenceMember[numberOfMembers];
            Length = numberOfMembers;
            _sequenceMembers[0] = new SequenceMember(firstMember, 0);
            _sequenceMembers[1] = new SequenceMember(secondMember, 1);
            _sequenceMembers[2] = new SequenceMember(thirdMember, 2);
            GenerateMember(numberOfMembers - 1);
        }

        private SequenceMember GenerateMember(int numberOfMember)
        {
            if (numberOfMember < 3)
            {
                return _sequenceMembers[numberOfMember];
            }

            _sequenceMembers[numberOfMember] = 13 * GenerateMember(numberOfMember - 1) +
                                               10 * GenerateMember(numberOfMember - 2) +
                                               GenerateMember(numberOfMember - 3);
            _sequenceMembers[numberOfMember].Index = numberOfMember;
            return _sequenceMembers[numberOfMember];
        }

        public SequenceMember this[int index]
        {
            get
            {
                if (index < 0 | index >= _sequenceMembers.Length) throw new WrongSequenceMemberIndex(index);
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