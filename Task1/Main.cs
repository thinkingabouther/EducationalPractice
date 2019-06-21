using System;
using System.Collections.Generic;

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
                    if (SphereIntersection(currentSphere, sphere))
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

        public static bool SphereIntersection(Sphere a, Sphere b)
        {
            double distance = Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y) + (a.Z - b.Z) * (a.Z - b.Z));
            return distance < a.Radius + b.Radius;
        }
    }
}