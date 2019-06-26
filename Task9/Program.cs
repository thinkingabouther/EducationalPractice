using System;

namespace Task9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                bool flag = false;
                int size;
                do
                {
                    size = Utilities.ConsoleInputParse.Int("Input the list size");
                    if (size < 1)
                    {
                        Console.WriteLine("Size should be positive!");
                    }
                    else
                    {
                        flag = true;
                    }
                } while (!flag);

                var list = new CycledList(size);
                Console.WriteLine(list.GetAllMembers());
                Console.WriteLine(
                    $"The index of member with given value is {list.FindByValue(Utilities.ConsoleInputParse.Int("Input value to find"))}");
                list.DeleteByValue(Utilities.ConsoleInputParse.Int("Input value to delete"));
                Console.WriteLine(list.GetAllMembers());
                Console.Read();
            }
            catch (ValueNotFoundException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}