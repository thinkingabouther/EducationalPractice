using System;

namespace Task1
{
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
            X = Double.Parse(data[0]);
            Y = Double.Parse(data[1]);
            Z = Double.Parse(data[2]);
            Radius = Double.Parse(data[3]);
        }

        public override string ToString()
        {
            return $"X={X}, Y={Y}, Z={Z}, R={Radius}";
        }

        public static bool SphereIntersection(Sphere a, Sphere b)
        {
            double distance = Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y) + (a.Z - b.Z) * (a.Z - b.Z));
            return distance < a.Radius + b.Radius;
        }
    }
}