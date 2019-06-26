using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Threading;
using Utilities;

namespace Task6
{
    [ExcludeFromCodeCoverage]
    internal static class MainProgram
    {
        public static void Main(string[] args)
        {
            try
            {



                int a1 = ConsoleInputParse.Int("Input the first element of the sequence",
                    "Incorrect input (should be integer)");
                int a2 = ConsoleInputParse.Int("Input the second element of the sequence",
                    "Incorrect input (should be integer)");
                int a3 = ConsoleInputParse.Int("Input the third element of the sequence",
                    "Incorrect input (should be integer)");

                int n = ConsoleInputParse.Int("Input the number of elements of the sequence",
                    "Incorrect input, should be integer");
                Console.WriteLine();
                Sequence sequence = new Sequence(a1, a2, a3, n);
                foreach (var sequenceMember in sequence)
                {
                    Console.WriteLine(sequenceMember);
                }

                Console.WriteLine(sequence.IsRisingSequenceEvenElements()
                    ? "Even elements of the sequence form a rising subsequence"
                    : "Event element of the sequence do not form a rising subsequence");
            }
            catch (WrongSequenceLengthException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (TooBigNumbersException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (WrongSequenceMemberIndexException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}