using System;
using System.Collections.Generic;
using System.IO;

namespace Task1
{
    internal static class MainProgram
    {
        public static void Main(string[] args)
        {
            string[] data = FileSystemManager.FileReader(@"/Users/arsenyneustroev/RiderProjects/EducationalPractice/Task1/TestingData/INPUT.TXT");
            List<Sphere> sphereList = new List<Sphere>();
            Sphere mainSphere = new Sphere(data[0]);
            sphereList.Add(mainSphere);
            int answerNumber = 0;
            for (int i = 1; i < data.Length; i++)
            {
                data[i] = data[i].Replace('.', ',');
                Sphere currentSphere = new Sphere(data[i]);
                foreach (Sphere sphere in sphereList)
                {
                    if (SphereIntersesction(currentSphere, sphere))
                    {
                        sphere.Intersected = true;
                        currentSphere.Intersected = true;
                    }
                }
                sphereList.Add(currentSphere);
                bool exit = true;
                foreach (Sphere sphere in sphereList)
                {
                    if (sphere.Intersected) continue;
                    exit = false;
                    break;
                }

                if (exit)
                {
                    answerNumber = i;
                    break;
                }
            }
            //Console.WriteLine(numberOfIntersectedSpheres);
            FileSystemManager.FileWriter(answerNumber, @"/Users/arsenyneustroev/RiderProjects/EducationalPractice/Task1/TestingData/OUTPUT.TXT");


        }

        public static bool SphereIntersesction(Sphere a, Sphere b)
        {
            double distance = Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y) + (a.Z - b.Z) * (a.Z - b.Z));
            return distance < a.Radius + b.Radius;
        }
    }

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

    public class Sphere
    {
        public readonly double X;
        public readonly double Y;
        public readonly double Z;
        public readonly double Radius;
        public bool Intersected = false;

        public Sphere(string inputString)
        {
            string[] data = inputString.Split(' ');
            X = double.Parse(data[0]);
            Y = double.Parse(data[1]);
            Z = double.Parse(data[2]);
            Radius = double.Parse(data[3]);
        }

        public override string ToString()
        {
            return $"X={X}, Y={Y}, Z={Z}, R={Radius}";
        }
    }
}