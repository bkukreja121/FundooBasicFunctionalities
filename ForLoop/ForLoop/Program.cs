using System;

namespace ForLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cars = { "BMW", "AUDI", "VOLVO" };
            foreach(string i in cars)
            {
                Console.WriteLine(i);
            }
        }
    }
}
