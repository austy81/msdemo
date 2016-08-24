using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var change = new Change();
            var numberOfDenominations = change.MakeChange(222);
            Console.WriteLine(numberOfDenominations);
        }
    }
}
