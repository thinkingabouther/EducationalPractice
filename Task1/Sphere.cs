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