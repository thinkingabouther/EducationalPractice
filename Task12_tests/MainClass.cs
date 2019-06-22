using System;
using System.Collections.Generic;

namespace Task12
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            int[] lengths = {10, 100, 1000};
            foreach (int length in lengths)
            {
                Console.WriteLine($"--------Working with {length} length of array--------");
                int swapsCount;
                int compCount;
                for (int i = 0; i < 3; i++)
                {
                    if (i == 0) Console.WriteLine("Not sorted array:");
                    if (i == 1) Console.WriteLine("Sorted array:");
                    if (i == 2) Console.WriteLine("Reversed array:");
                    ArrayWithLineValues array = new ArrayWithLineValues(length);
                    array.CountingSort(i, out compCount, out swapsCount);
                    Console.WriteLine($"For counting sort - {swapsCount} swaps and {compCount} comparisons");
                    array.SelectionSort(i, out compCount, out swapsCount);
                    Console.WriteLine($"For selection sort - {swapsCount} swaps and {compCount} comparisons");
                    Console.WriteLine();

                }
                Console.WriteLine();

            }
            
            
        }
        
    }
}