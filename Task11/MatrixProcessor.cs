using System;
using System.Collections.Generic;
using System.IO;

namespace Task11
{
    public class MatrixProcessor
    {
        public int[,] KeyMatrix;

        public char[,] EncodeMessage(string message)
        {
            char[,] outputMessage = new char[KeyMatrix.GetLength(0), KeyMatrix.GetLength(0)];
            int curIndex = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < KeyMatrix.GetLength(0); j++)
                {
                    for (int k = 0; k < KeyMatrix.GetLength(1); k++)
                    {
                        if (KeyMatrix[j, k] == 1)
                        {
                            outputMessage[j, k] = message[curIndex];
                            curIndex++;
                        }
                    }
                }
                RotateKeyMatrix();
            }

            return outputMessage;
        }

        public void UploadMatrix(string fileName)
        {
            KeyMatrix = FileSystemManager.ReadIntMatrix(fileName);
        }

        public void RotateKeyMatrix()
        {
            var result = new int[KeyMatrix.GetLength(1), KeyMatrix.GetLength(0)];
 
            for (int i = 0; i < KeyMatrix.GetLength(1); i++)
            for (int j = 0; j < KeyMatrix.GetLength(0); j++)
                result[i, j] = KeyMatrix[KeyMatrix.GetLength(0) - j - 1, i];
            KeyMatrix = result;

        }

        public char[,] DecodeMessage(string message)
        {
            char[,] inputMessage = new char[KeyMatrix.GetLength(0), KeyMatrix.GetLength(0)];
            var curIndex = 0;
            for (int i = 0; i < KeyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < KeyMatrix.GetLength(0); j++)
                {
                    inputMessage[i, j] = message[curIndex];
                    curIndex++;
                }
            }
            

            string outputMessage = "";
            for (int k = 0; k < 4; k++)
            {
                for (int i = 0; i < KeyMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < KeyMatrix.GetLength(0); j++)
                    {
                        if (KeyMatrix[i, j] == 1)
                        {
                            outputMessage += inputMessage[i, j];
                        }
                    }
                }
                RotateKeyMatrix();
            }
            char[,] outputMatrix = new char[KeyMatrix.GetLength(0), KeyMatrix.GetLength(0)];
            curIndex = 0;
            for (int i = 0; i < KeyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < KeyMatrix.GetLength(0); j++)
                {
                    outputMatrix[i, j] = outputMessage[curIndex];
                    curIndex++;
                }
            }

            return outputMatrix;

        }

        public int[,] GenerateKeyMatrix(int size)
        {
            Random rnd = new Random();
            int[,] newMatrix = new int[size, size];
            List<Position> possiblePositions = new List<Position>();
            List<Position> actualPositions = new List<Position>();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    possiblePositions.Add(new Position(i, j));
                }
            }

            for (int k = 0; k < size*size / 4; k++)
            {
                Position currPosition = possiblePositions[rnd.Next(possiblePositions.Count)];
                actualPositions.Add(currPosition);
                //Console.WriteLine($"Chosen position - {currPosition}");
                for (int i = 0; i < possiblePositions.Count; i++)
                {
                    if (currPosition.IsSymmetric(possiblePositions[i], size))
                    {
                        //Console.WriteLine($"To remove {possiblePositions[i]}");
                        possiblePositions.Remove(possiblePositions[i]);
                        i = i - 1;
                    }

                }
                //Console.WriteLine($"{possiblePositions.Count}, {actualPositions.Count}");
            }

            foreach (Position actualPosition in actualPositions)
            {
                newMatrix[actualPosition.I, actualPosition.J] = 1;
            }

            return newMatrix;
        }

        public void ShowMatrix(int[,] matrix)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j != 9)
                        Console.Write(matrix[i, j] + " ");
                    else Console.Write(matrix[i, j]);
                }
                if(i != 9)
                    Console.WriteLine();
            }
        }
        
        public void ShowMatrix(char[,] matrix)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j != 9)
                        Console.Write(matrix[i, j] + " ");
                    else Console.Write(matrix[i, j]);
                }
                if(i != 9)
                    Console.WriteLine();
            }
        }

        private class Position
        {
            public int I;
            public int J;

            public override string ToString()
            {
                return $"i-{I}, j-{J}";
            }

            public Position(int i, int j)
            {
                I = i;
                J = j;
            }

            public bool IsSymmetric(Position candidate, int size)
            {
                return candidate.I == I & candidate.J == J ||
                       candidate.I == size - I - 1 & candidate.J == J ||
                       candidate.I == size - I - 1 & candidate.J == size - J - 1 ||
                       candidate.I == I & candidate.J == size - J - 1;
            }
        }
    }
    
    
    public static class FileSystemManager
    {
        private static int _matrixSize = 10;
        
        public static int[,] ReadIntMatrix(string filePath)
        {
            int[,] matrix = new int[_matrixSize, _matrixSize];
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                string currFile = streamReader.ReadToEnd();
                string[] strings = currFile.Split('\n');
                int i = 0;
                foreach (string s in strings)
                {
                    var stringWithNums = s.Split(' ');
                    for (int j = 0; j < _matrixSize; j++)
                    {
                        matrix[i, j] = int.Parse(stringWithNums[j]);
                    }
                    i++;
                }
            }
            return matrix;
        }
        
        public static char[,] ReadCharMatrix(string filePath)
        {
            char[,] matrix = new char[_matrixSize, _matrixSize];
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                string currFile = streamReader.ReadToEnd();
                string[] strings = currFile.Split('\n');
                int i = 0;
                foreach (string s in strings)
                {
                    var stringWithNums = s.Split(' ');
                    for (int j = 0; j < _matrixSize; j++)
                    {
                        matrix[i, j] = stringWithNums[j][0];
                    }
                    i++;
                }
            }
            return matrix;
        }

        public static string ReadMessage(string filePath)
        {
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                return streamReader.ReadToEnd();
            }
        }

        public static void WriteMessage(string filePath, char[,] matrix)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (j != 9)
                            streamWriter.Write(matrix[i, j] + " ");
                        else streamWriter.Write(matrix[i, j]);
                    }

                    if (i != 9)
                        streamWriter.WriteLine();
                }
            }
        }
    }
}