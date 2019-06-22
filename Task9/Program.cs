using System;

namespace Task9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var list = new CycledList(Utilities.ConsoleInputParse.Int("Input the list size"));
            Console.WriteLine(list.GetAllMembers());
            Console.WriteLine($"The index of member with given value is {list.FindByValue(Utilities.ConsoleInputParse.Int("Input value to find"))}");
            list.DeleteByValue(Utilities.ConsoleInputParse.Int("Input value to delete"));
            Console.WriteLine(list.GetAllMembers());
        }
    }
}