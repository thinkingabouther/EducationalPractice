using System;
using NUnit.Framework;
using Task6;

namespace TestsForTasks
{
    [TestFixture]
    public class Task6Tests
    {
        /// <summary>
        /// Check the exception thrown if creating Sequence with length less than 0 or more than possible (Stack Overflow) 
        /// </summary>
        [Test]
        [TestCase(-1)]
        public void CreatingSequenceWithWrongLength(int length)
        {
            Assert.Throws<WrongSequenceLengthException>(delegate
            {
                Sequence sequence = new Sequence(1, 1, 1, length);
            });
        }

        /// <summary>
        /// Check if the elements of the sequence are properly calculated 
        /// </summary>
        [Test]
        public void ProperElementOfSequenceCheck()
        {
            string expectedOutput =
                "The 1 element of the sequence is 1 The 2 element of the sequence is 2 The 3 element of the sequence is 3 The 4 element of the sequence is 60 The 5 element of the sequence is 812 ";
            string factualOutput = "";
            Sequence sequence = new Sequence(1, 2, 3, 5);
            foreach (var sequenceMember in sequence)
            {
                factualOutput += sequenceMember.ToString() + " ";
            }

            Assert.IsTrue(expectedOutput == factualOutput);
        }

        /// <summary>
        /// Check the indexer of Sequence throwing exception when calling with index less than 0 or bigger than (length of sequence - 1)
        /// </summary>
        [Test]
        [TestCase(-1)] // index is less than zero
        [TestCase(-10)] // index is bigger than (length of sequence - 1)
        public void CheckIndexerOutOfRangeOfSequence(int index)
        {
            Sequence sequence = new Sequence(1, 2, 3, 9);
            Assert.Throws<WrongSequenceMemberIndexException>(
                delegate // using a delegate to control the exception thrown when calling the wrong index 
                {
                    var sequenceMember = sequence[index];
                });
        }

        [Test]
        public void CheckBigNumbersCausingException()
        {
            Assert.Throws<TooBigNumbersException>(delegate { new Sequence(1, 2, 3, 20); });
        }

    }
}