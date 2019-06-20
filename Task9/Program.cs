using System;

namespace Task9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var list = new CycledList(5);
            Console.WriteLine(list.GetAllMembers());
            Console.WriteLine(list.FindByIndex(3));
        }
    }
}