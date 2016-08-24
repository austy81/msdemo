using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class Change
    {
        public int MakeChange(int amount)
        {
            int[] denominations = new int [6] {100, 50, 20, 10, 5, 1};
            int billsCount = 0;
            int remainingAmount = amount;
            Console.WriteLine($"initial amount = {amount}");
            Console.WriteLine("You need following bills:");
            foreach(int denomination in denominations)
            {
                while(remainingAmount >= denomination)
                { 
                    remainingAmount -= denomination;
                    billsCount++;
                    Console.WriteLine(denomination);
                }
            }
            Console.WriteLine($"Total number of bills is: {billsCount}");
            return billsCount;
        }
    }
}
