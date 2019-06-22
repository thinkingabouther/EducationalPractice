using System;
using System.Collections.Generic;

namespace Task12
{
    public class WrongArrayElementIndex : Exception
    {
        public WrongArrayElementIndex(int index) : base(ModifyExceptionMessage(index))
        {

        }

        private static string ModifyExceptionMessage(int index)
        {
            return $"{index} cannot be used as an index of this element of an array";
        }

    }

    public class WrongArrayLengthException : Exception
    {
        public WrongArrayLengthException(int length) : base(ModifyExceptionMessage(length))
        {

        }

        private static string ModifyExceptionMessage(int length)
        {
            return $"{length} cannot be used as a length of an array. Try positive integer";
        }

    }

    public class ArrayElement : IComparable
    {
        public int Value;
        public int? XPosition = null;

        public ArrayElement(int value)
        {
            Value = value;
        }

        public static bool operator >(ArrayElement a, ArrayElement b)
        {
            return (a.Value > b.Value);
        }

        public static bool operator <(ArrayElement a, ArrayElement b)
        {
            return !(a > b);
        }

        public static implicit operator int(ArrayElement a)
        {
            return a.Value;
        }

        public override string ToString()
        {
            return $"value - {Value}, XPosition - {XPosition}";
        }

        public int CompareTo(object obj)
        {
            var temp = (ArrayElement) obj;
            return this.Value.CompareTo(temp.Value);
        }
    }

    public class ArrayWithLineValues
    {
        private int _length;
        private List<ArrayElement> _arrayElements;


        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < Length; i++)
            {
                output += $"Element with index {i + 1} is {this[i].ToString()}\n";
            }

            return output;
        }

        public ArrayWithLineValues(int length)
        {
            this.Length = length;
            _arrayElements = new List<ArrayElement>();
            RandomFill();
        }

        public int MaximumValue { get; set; } = 250;

        public void SelectionSort(int mode, out int NumOfCompares, out int NumOfSwaps)
        {

            if (mode == 0) // non-sorted
            {
                RandomFill();
            }
            if (mode == 1) // already sorted
            {
                _arrayElements.Sort();
            }

            if (mode == 2) // reversed
            {
                _arrayElements.Sort();
                _arrayElements.Reverse();
            }
            int numOfCompares = 0;
            int numOfSwaps = 0;
            {
                for (int i = 0; i < Length - 1; i++)
                {
                    var minIndex = i;
                    for (int j = i + 1; j < Length; j++)
                    {
                        numOfCompares++;
                        if (this[j] < this[minIndex])
                        {
                            minIndex = j;
                        }
                    }

                    numOfSwaps++;
                    SwapElements(i, minIndex);
                }
                NumOfCompares = numOfCompares;
                NumOfSwaps = numOfSwaps;
            }
        }

        public void CountingSort(int mode, out int NumOfCompares, out int NumOfSwaps)
        {
            
            if (mode == 0) // non-sorted
            {
                RandomFill();
            }
            if (mode == 1) // already sorted
            {
                _arrayElements.Sort();
            }

            if (mode == 2) // reversed
            {
                _arrayElements.Sort();
                _arrayElements.Reverse();
            }

            int numOfCompares = 0;
            int numOfSwaps = 0;
            ArrayWithLineValues tempArray = new ArrayWithLineValues(Length);
            {
                for (int i = 0; i < Length; i++)
                {
                    int c = 0;
                    for (int j = 0; j < i; j++)
                    {
                        numOfCompares++;
                        if (this[j] <= this[i])
                        {
                            c++;
                        }
                    }

                    for (int j = i + 1; j < Length; j++)
                    {
                        numOfCompares++;
                        if (this[j] < this[i])
                        {
                            c++;
                        }
                    }
                    tempArray[c] = new ArrayElement(this[i].Value);
                }
                tempArray._arrayElements.Sort();
                for (int i = 0; i < Length; i++)
                {
                    numOfSwaps++;
                    this[i] = new ArrayElement(tempArray[i].Value);
                }
                NumOfCompares = numOfCompares;
                NumOfSwaps = numOfSwaps;
            }
        }



        public void SwapElements(int index1, int index2)
        {
            ArrayElement temp1 = this[index1];
            ArrayElement temp2 = this[index2];
            //if (temp1.XPosition != null && temp2.XPosition != null)
            //{
            //    int? tempX = temp1.XPosition;
            //    temp1.XPosition = temp2.XPosition;
            //    temp2.XPosition = tempX;
            //}
            this._arrayElements.RemoveAt(index1);
            this._arrayElements.Insert(index1, temp2);
            this._arrayElements.RemoveAt(index2);
            this._arrayElements.Insert(index2, temp1);
        }

        public ArrayElement this[int index]
        {
            get => _arrayElements[index];
            set => _arrayElements[index] = value;
        } 

        public void RandomFill()
        {
            _arrayElements = new List<ArrayElement>();
            Random rnd = new Random();
            for (int i = 0; i < Length; i++)
            {
                _arrayElements.Add(new ArrayElement(rnd.Next(MaximumValue)));
            }
        }

        public int Length
        {
            get => this._length;
            set
            {
                if (value < 1)
                {
                    throw new WrongArrayLengthException(value);
                }

                this._length = value;
            }
        }
    }
}