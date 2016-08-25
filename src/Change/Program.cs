using System; 
using System.IO; 
using System.Linq;
using Microsoft.Extensions.Configuration; 


namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            
            string denominationsString = config["denominations"];
            var denominations = denominationsString.Split(',').Select(int.Parse);

            int amount = 0;
            if(args.Length == 1) {
                amount = Convert.ToInt32(args[0]);
            }
            else
            {
                Random rnd = new Random();
                amount = rnd.Next(1,999);
                Console.WriteLine("Specify amount you want to change in the parameter.");
                Console.WriteLine($"For demo purpose it will be used number {amount}");
            }
            
            var change = new Change(denominations);
            var billsCount = change.MakeChange(amount);
            
            Console.WriteLine($"If we have following amount of money: {amount}");
            Console.WriteLine($"And we have following bills: {denominationsString}");
            Console.WriteLine($"This is smallest number of bills for given amount: {billsCount}");
        }
    }

}
