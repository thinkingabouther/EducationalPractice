using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task5;


namespace Tests
{
    [TestClass]
    public class Task5Tests
    {
        [TestMethod]
        public void EvenSidedMatrixGetSum()
        {
            var matrix = new Matrix(4);
            double sum = 0;
            foreach (var matrixElement in matrix)
            {
                var element = (MatrixElement) matrixElement;
                if ((element.I >= element.J & matrix.MatrixSize - 1 - element.I >= element.J) |
                    (element.J >= element.I & matrix.MatrixSize - 1 - element.I <= element.J))
                {
                    sum += element.Value;
                }
            }

            Assert.IsTrue(Math.Abs(sum - matrix.GetSumOfElements()) < 0.0001);
        }

        [TestMethod]
        public void OddSidedMatrixGetSum()
        {
            var matrix = new Matrix(5);
            double sum = 0;
            foreach (var matrixElement in matrix)
            {
                var element = (MatrixElement) matrixElement;
                if ((element.I >= element.J & matrix.MatrixSize - 1 - element.I >= element.J) |
                    (element.J >= element.I & matrix.MatrixSize - 1 - element.I <= element.J))
                {
                    sum += element.Value;
                }
            }

            Assert.IsTrue(Math.Abs(sum - matrix.GetSumOfElements()) < 0.0001);
        }

        [TestMethod]
        public void EvenSidedMatrixGetMax()
        {
            var matrix = new Matrix(4);
            var max = double.MinValue;
            foreach (var matrixElement in matrix)
            {
                var element = (MatrixElement) matrixElement;
                if ((element.I >= element.J & matrix.MatrixSize - 1 - element.I >= element.J) |
                    (element.J >= element.I & matrix.MatrixSize - 1 - element.I <= element.J))
                {
                    if (element.Value > max) max = element.Value;
                }
            }

            Assert.IsTrue(Math.Abs(max - matrix.GetMaximumOfElements()) < 0.0001);
        }

        [TestMethod]
        public void OddSidedMatrixGetMax()
        {
            var matrix = new Matrix(5);
            var max = double.MinValue;
            foreach (var matrixElement in matrix)
            {
                var element = (MatrixElement) matrixElement;
                if ((element.I >= element.J & matrix.MatrixSize - 1 - element.I >= element.J) |
                    (element.J >= element.I & matrix.MatrixSize - 1 - element.I <= element.J))
                {
                    if (element.Value > max) max = element.Value;
                }
            }

            Assert.IsTrue(Math.Abs(max - matrix.GetMaximumOfElements()) < 0.0001);
        }

        [DataRow(-1, 0)]
        [DataRow(0, -1)]
        [TestMethod]
        public void WrongIndexException(int i, int j)
        {
            Assert.ThrowsException<WrongMatrixIndex>(delegate { new MatrixElement(i, j, 0); });
        }

        [TestMethod]
        public void WrongMatrixSizeException()
        {
            Assert.ThrowsException<WrongMatrixSize>(delegate { new Matrix(-1); });
        }

        [DataRow(1, 0)]
        [DataRow(0, 1)]
        [TestMethod]
        public void TryingToGetValue(int i, int j)
        {
            var matrix = new Matrix(4);
            var temp = matrix[i, j];
            Assert.IsTrue(temp.I == i);
        }

        [DataRow(-1, 0)]
        [TestMethod]
        public void TryingToSetValueWihWrongIndex(int i, int j)
        {
            var matrix = new Matrix(3);
            matrix[i, j] = new MatrixElement(5, 5, 10); 
        }

    }

}