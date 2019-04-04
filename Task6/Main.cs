using System;
namespace Task6
{
    internal static class MainProgram
    {
        public static void Main(string[] args)
        {
            Sequence sequence = new Sequence(1, 2, 3, 10);
            Console.WriteLine(sequence[10]);
        }
    }

    class Sequence
    {
        private readonly int[] _sequenceMembers;
        public Sequence(int firstMember, int secondMember, int thirdMember, int numberOfMembers)
        {
            _sequenceMembers = new int[numberOfMembers];
            _sequenceMembers[0] = firstMember;
            _sequenceMembers[1] = secondMember;
            _sequenceMembers[2] = thirdMember;
            GenerateMember(numberOfMembers - 1);
        }

        private int GenerateMember(int numberOfMember)
        {
            if (numberOfMember < 3)
            {
                return _sequenceMembers[numberOfMember];
            }

            _sequenceMembers[numberOfMember] = 13 * GenerateMember(numberOfMember - 1) +
                                               10 * GenerateMember(numberOfMember - 2) +
                                               GenerateMember(numberOfMember - 3);
            return _sequenceMembers[numberOfMember];
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 | index >= _sequenceMembers.Length) throw new WrongSequenceMemberIndex(index);
                return _sequenceMembers[index];
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