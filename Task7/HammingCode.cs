using System;

namespace Task7
{
    public class HammingCode
    {
        private char[] CurrWord { get; }
        private bool _isProcessed; 

        public HammingCode(string currWord)
        {
            CurrWord = currWord.ToCharArray();
        }

        public int GetSummByControlBitIndex(int index)
        {
            int sum = 0;
            int step = (int)Math.Pow(2, index);
            for (int i = step - 1; i < CurrWord.Length; i = i + 2*step)
            {
                for (int j = i; j < i + step & j < CurrWord.Length ; j++)
                {
                    sum += int.Parse(CurrWord[j].ToString());
                }
            }

            return sum - int.Parse(CurrWord[(int)Math.Pow(2, index) - 1].ToString());
        }

        public int ProcessHammingCode() // returning true if there is no error
        {
            int sumOfPositions = 0;
            int numOfControlBits = 0;
            while ((int) Math.Pow(2, numOfControlBits) < CurrWord.Length + numOfControlBits - 1)
            {
                numOfControlBits++;
            }

            for (int i = 0; i < numOfControlBits; i++)
            {
                int indexOfContolBit = (int) Math.Pow(2, i) - 1;
                int controlSum = GetSummByControlBitIndex(i);
//                Console.WriteLine($"Working with control bit - {i}");
//                Console.WriteLine($"Сontrol summ - {controlSum}");
//                Console.WriteLine($"index of control bit - {indexOfContolBit}");
//                Console.WriteLine($"Control bit - {int.Parse(CurrWord[indexOfContolBit].ToString())}");
//                Console.WriteLine();
                if (controlSum % 2 != int.Parse(CurrWord[indexOfContolBit].ToString()))
                {
                    sumOfPositions += indexOfContolBit + 1;
                }
            }

            if (sumOfPositions != 0)
            {
                if (CurrWord[sumOfPositions - 1] == '0')
                {
                    CurrWord[sumOfPositions - 1] = '1';
                }
                else
                {
                    CurrWord[sumOfPositions - 1] = '0';
                }
            }

            _isProcessed = true;
            return sumOfPositions;
        }

        public override string ToString()
        {
            if (_isProcessed)
                return new string(CurrWord);
            throw new NotProcessedHammingCodeException();
        }

        public class NotProcessedHammingCodeException : Exception
        {
            public NotProcessedHammingCodeException() : base("Code was not processed")
            {
                
            }
        }
    }
}