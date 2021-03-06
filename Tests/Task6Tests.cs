using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task6;

namespace Tests
{
    [TestClass]
    public class Task6Tests
    {
    
        /// <summary>
        /// Check the exception thrown if creating Sequence with length less than 0 or more than possible (Stack Overflow) 
        /// </summary>
        [TestMethod]
        [DataRow(-1)]
        public void CreatingSequenceWithWrongLength(int length)
        {
            Assert.ThrowsException<WrongSequenceLengthException>(delegate
            {
                Sequence sequence = new Sequence(1, 1, 1, length);
            });
        }

        /// <summary>
        /// Check if the elements of the sequence are properly calculated 
        /// </summary>
        [TestMethod]
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
        [TestMethod]
        [DataRow(-1)] // index is less than zero
        [DataRow(-10)] // index is bigger than (length of sequence - 1)
        public void IndexerOutOfRangeOfSequence(int index)
        {
            Sequence sequence = new Sequence(1, 2, 3, 9);
            Assert.ThrowsException<WrongSequenceMemberIndexException>(
                delegate // using a delegate to control the exception thrown when calling the wrong index 
                {
                    var sequenceMember = sequence[index];
                });
        }

        [TestMethod]
        public void BigNumbersCausingException()
        {
            Assert.ThrowsException<TooBigNumbersException>(
                delegate
                {
                    new Sequence(1, 2, 3, 20); 
                    
                });
        }
        /// <summary>
        /// Check the detection of rising subsequence on places with even numbers 
        /// </summary>
        [TestMethod]
        public void RisingEvenSubsequence_True()
        {
            Sequence sequence = new Sequence(1, 2, 3, 5);
            Assert.IsTrue(sequence.IsRisingSequenceEvenElements());
        }
        /// <summary>
        /// Check the detection of not rising subsequence on places with even numbers 
        /// </summary>
        [TestMethod]
        public void RisingEvenSubsequence_False()
        {
            Sequence sequence = new Sequence(-1, -2, -3, 6);
            Assert.IsFalse(sequence.IsRisingSequenceEvenElements());
        }

        [TestMethod]
        public void ForEachEnumeratingTest()
        {
            Sequence sequence = new Sequence(1, 1, 1, 5);
            string output = "";
            foreach (SequenceMember sequenceMember in sequence)
            {
                output += sequenceMember.ToString();
            }
            Assert.IsTrue(output.Length > 0);
        }
    }
}