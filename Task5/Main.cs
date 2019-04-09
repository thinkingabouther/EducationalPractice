using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Mime;
using System.Linq;
using System.Reflection;
using Utilities;

namespace Task5
{
    internal static class MainProgram
    {
        public static void Main(string[] args)
        {
            Matrix matrix = new Matrix(4);
            Console.WriteLine();
            matrix.ShowMatrix();
            Console.WriteLine(matrix.GetSumOfElements());
        }
    }

    public class MatrixElement
    {
        private int _i;
        private int _j;
        public readonly double Value;

        public MatrixElement(int i, int j, double value)
        {
            I = i;
            J = j;
            Value = value;
        }

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
            set
            {
                if (indexJ >= MatrixSize) throw new WrongMatrixIndex(indexJ);
                if (indexI >= MatrixSize) throw new WrongMatrixIndex(indexI);
                if (indexI != value.I || indexJ != value.J) throw new WrongMatrixMemberInstance("Current MatrixMember instance has different indexes compared to the indexer values");
                _matrixElements.Add(value);
            }
            get
            {
                if (indexI >= MatrixSize) throw new WrongMatrixIndex(indexI);
                if (indexJ >= MatrixSize) throw new WrongMatrixIndex(indexJ);
                
                return (from element in this where element.I == indexI && element.J == indexJ select element).First();
            } 
        }

        public Matrix(int matrixSize, bool random = true)
        {
            MatrixSize = matrixSize;
            _matrixElements = new List<MatrixElement>();
            _random = random;
            MatrixFill();
        }

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
                Console.WriteLine(matrixElement);
                sum += matrixElement.Value;
            }

            return sum;
        }

        public IEnumerator GetEnumerator()
        {
            return _matrixElements.GetEnumerator();
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
    public class WrongMatrixMemberInstance : Exception
    {
        public WrongMatrixMemberInstance(string message) : base(message)
        {
            
        }
    }
    
    
}