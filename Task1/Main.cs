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
            Sphere mainSphere = new Sphere(data[0]); // Processing main sphere (first from file)
            sphereList.Add(mainSphere);
            int answerNumber = 0;
            
            for (int i = 1; i < data.Length; i++)
            {
                data[i] = data[i].Replace('.', ',');
                Sphere currentSphere = new Sphere(data[i]);
                foreach (Sphere sphere in sphereList) // Looking for all spheres which are already added to a list
                {
                    if (Sphere.SphereIntersection(currentSphere, sphere)) 
                    {
                        sphere.Intersected = true;
                        currentSphere.Intersected = true;
                    }
                }
                
                sphereList.Add(currentSphere);
                bool exit = true;
                foreach (Sphere sphere in sphereList) // Checking if all spheres at the moment are intersected. If so, returning the answer
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
    }
}