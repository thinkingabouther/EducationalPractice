using System;
using System.IO;

namespace Task1
{
    public static class FileSystemManager
    {
        public static string[] FileReader(string filePath)
        {
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                string mainSphere = streamReader.ReadLine();
                int numberOfSpheres = Int32.Parse(streamReader.ReadLine());

                string[] outputArray = new string[numberOfSpheres + 1];
                outputArray[0] = mainSphere;

                for (int i = 1; i <= numberOfSpheres; i++)
                {
                    outputArray[i] = streamReader.ReadLine();
                }

                return outputArray;
            }
        }

        public static void FileWriter(int number, string filePath)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath)) streamWriter.WriteLine(number.ToString());
        }
    }
}