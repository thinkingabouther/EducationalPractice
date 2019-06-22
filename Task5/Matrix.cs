using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Utilities;

namespace Task5
{
    

    public class MatrixElement
    {
        private int _i;
        private int _j;
        public double Value { get; set; }

        public MatrixElement(int i, int j, double value)
        {
            I = i;
            J = j;
            Value = value;
        }
        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return $"Matrix element with indexes {_i}, {_j} is {Value}";
        }

        public int I
        {
            get => _i;
            set
            {
                if (value < 0) throw new WrongMatrixIndex(value);
                _i = value;
            }
        }
        
        public int J
        {
            get => _j;
            set
            {
                if (value < 0) throw new WrongMatrixIndex(value);
                _j = value;
            }
        }
    }

    public class Matrix : IEnumerable<MatrixElement>
    {
        private readonly List<MatrixElement> _matrixElements;
        
        private int _matrixSize;
        
        private readonly bool _random;

        public int MatrixSize
        {
            get => _matrixSize;
            set
            {
                if (value < 0) throw new WrongMatrixSize(value);
                _matrixSize = value;
            }
        }

        public MatrixElement this[int indexI, int indexJ]
        {
            set => _matrixElements.Add(value);
            get => (from element in this where element.I == indexI && element.J == indexJ select element).First();
        }

        public Matrix(int matrixSize, bool random = true)
        {
            MatrixSize = matrixSize;
            _matrixElements = new List<MatrixElement>();
            _random = random;
            MatrixFill();
        }
        [ExcludeFromCodeCoverage]
        private void MatrixFill()
        {
            for (int i = 0; i < MatrixSize; i++)
            {
                for (int j = 0; j < MatrixSize; j++)
                {
                    if (!_random)
                        this[i, j] = new MatrixElement(i, j, ConsoleInputParse.Double(
                            $"Input the element with indexes {i}, {j}",
                            "Incorrect input. Should be double"));
                    else
                        this[i,j] = new MatrixElement(i, j, GetRandomValues.GetRandomDouble(-100, 100));
                }
            }
        }

        IEnumerator<MatrixElement> IEnumerable<MatrixElement>.GetEnumerator()
        {
            return _matrixElements.GetEnumerator();
        }
        [ExcludeFromCodeCoverage]
        public void ShowMatrix()
        {
            for (int i = 0; i < MatrixSize; i++)
            {
                Console.Write("|");
                for (int j = 0; j < MatrixSize; j++)
                {
                    Console.Write($" {this[i,j].Value, 5} |");
                }
                Console.WriteLine();
            }
        }

        public double GetSumOfElements()
        {
            double sum = 0;
            var elementsForSum = from element in this
                where (element.I >= element.J & MatrixSize - 1  - element.I >= element.J) | (element.J >= element.I & MatrixSize - 1 - element.I <= element.J)

                select element;
            foreach (MatrixElement matrixElement in elementsForSum)
            {
                sum += matrixElement.Value;
            }

            return sum;
        }

        public double GetMaximumOfElements()
        {
            var elementsForMaximum = from element in this
                where (element.I >= element.J & MatrixSize - 1  - element.I >= element.J) | (element.J >= element.I & MatrixSize - 1 - element.I <= element.J)

                select element.Value;
           

            return elementsForMaximum.Max(); 
        }

        public IEnumerator GetEnumerator()
        {
            return _matrixElements.GetEnumerator();
        }
    }
    [ExcludeFromCodeCoverage]
    public class WrongMatrixMemberInstance : Exception
    {
        public WrongMatrixMemberInstance(string message) : base(message)
        {
            
        }
    }
    [ExcludeFromCodeCoverage]
    public class WrongMatrixSize : Exception
    {
        public WrongMatrixSize(int x) : base(ModifyExceptionMessage(x))
        {
            
        }
        
        private static string ModifyExceptionMessage(int x)
        {
            return $"{x} is incorrect size for matrix. Try positive number";
        }
    }

    public class WrongMatrixIndex : Exception
    {
        public WrongMatrixIndex(int x) : base(ModifyExceptionMessageWithOneIndex(x))
        {
            
        }
        private static string ModifyExceptionMessageWithOneIndex(int x)
        {
            return $"{x} is incorrect index for matrix. Try positive number";
        }
    }
}