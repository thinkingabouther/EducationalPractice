using System;
using NUnit.Framework;
using Task4;

namespace TestsForTasks
{
    public class Task4Tests
    {
        /// <summary>
        /// Checks proper sum calculations when accuracy is configured properly  
        /// </summary>
        [Test]
        public void SumWithProperEpsilonInput()
        {
            double eps = 0.01;
            InfiniteSequence sequence = new InfiniteSequence(eps);
            double actualSum = 0;
            double expectedSum = 1.49139;
            foreach (ElementOfSequence elementOfSequence in sequence)
            {
                actualSum += elementOfSequence;
            }

            Assert.IsTrue(Math.Abs(actualSum - expectedSum) < 0.00001);
        }
        
        /// <summary>
        /// Checks ToString override of the elements of the sequence
        /// </summary>
        [Test]
        public void ElementOfSequenceWithConcreteNumber()
        {
            double eps = 0.01;
            InfiniteSequence sequence = new InfiniteSequence(eps);
            string expectedValue =
                "The element number 1 has value: 1 The element number 2 has value: 0.25 The element number 3 has value: 0.111111111111111 The element number 4 has value: 0.0625 The element number 5 has value: 0.04 The element number 6 has value: 0.0277777777777778 ";
            string acutalValue = "";
            foreach (ElementOfSequence elementOfSequence in sequence)
            {
                acutalValue += elementOfSequence;
            }

            Assert.IsTrue(expectedValue == acutalValue);
        }

        [Test]
        public void ExceptionThrownWhenAccuracyIsTooBig()
        {
            double eps = 0.000000000000000000000001;
            Assert.Throws<TooBigAccuracyException>(delegate
            {
                InfiniteSequence sequence = new InfiniteSequence(eps);
            });
        }
    }
}

