using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task12;

namespace Task12
{


    public class ArrayElement
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
    }
    public class ArrayWithLineValues
    {
        private int _length;
        private readonly List<ArrayElement> _arrayElements;


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

        public void SelectionSort(ref int currentHighlightedIndex1, ref int currentHighlightedIndex2,
            MainForm.RenderDelegate renderDelegate)
        {
            {
                for (int i = 0; i < Length - 1; i++)
                {
                    var minIndex = i;
                    for (int j = i + 1; j < Length; j++)
                    {
                        if (this[j] < this[minIndex])
                        {
                            minIndex = j;
                        }
                    }

                    currentHighlightedIndex1 = i;
                    currentHighlightedIndex2 = minIndex;
                    SwapElements(i, minIndex);
                    renderDelegate(i, minIndex);
                    Thread.Sleep(10);
                }

                currentHighlightedIndex1 = -1;
                currentHighlightedIndex2 = -2;
                renderDelegate(-1, -1);
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

        public ArrayElement this[int index] => _arrayElements[index];

        public void RandomFill()
        {
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
}

