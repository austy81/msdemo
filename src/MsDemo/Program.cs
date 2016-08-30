using System; 
using System.IO; 
using System.Linq;
using Microsoft.Extensions.Configuration; 


namespace msdemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Configuration init
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            
            ///////////// Change demo /////////////////////////
            string denominationsString = config["denominations"];
            var denominations = denominationsString.Split(',').Select(int.Parse);

            Random rnd = new Random();
            int amount = rnd.Next(1,999);
            Console.WriteLine("Change demo:");
            Console.WriteLine($"For demo purpose it will be used number {amount}");
            Console.WriteLine($"If we have following amount of money: {amount}");
            Console.WriteLine($"And we have following bills: {denominationsString}");

            var change = new Change(denominations);
            int billsCount;
            try
            {
                billsCount = change.MakeChange(amount);
                Console.WriteLine($"This is smallest number of bills for given amount: {billsCount}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            ////////////////////// StringManipulation Demo //////////////////////
            var aString = "Microsoft";
            var bString = "MS";
            var a = new StringManipulation(aString);
            var b = new StringManipulation(bString);
            Random rndShift = new Random();
            int shift = rndShift.Next(1,5);

            Console.WriteLine("");
            Console.WriteLine("StringManipulation demo:");
            var aRight = new StringManipulation(aString) >> shift;
            Console.WriteLine($"'{aString}' >> {shift} = '{aRight}'");
            var aLeft = new StringManipulation(aString) << shift;
            var aLeftString = aLeft.ToString();
            Console.WriteLine($"'{a}' << {shift} = '{aLeft}'");
            var aRef = aLeft << shift;
            Console.WriteLine($"'{aLeftString}' << {shift} = '{aRef}'");
            Console.WriteLine($"'{a}' == '{b}' = '{a == b}'");
            Console.WriteLine($"'{a}' != '{b}' = '{a != b}'");
        }
    }

}
