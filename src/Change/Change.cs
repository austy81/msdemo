using System.Collections.Generic;
using System.Linq;
using System;

namespace ConsoleApplication
{
    public class Change
    {
        IEnumerable<int> denominations_;
        public Change (IEnumerable<int> denomination) {
            denominations_ = denomination;
        }
        public int MakeChange(int amount)
        {
           Dictionary<int,int> denominationsCount = GetDenominationsCounts(amount);
           return denominationsCount.Sum(x=>x.Value);
        }

        internal protected Dictionary<int,int> GetDenominationsCounts(int amount)
        {
            var denominationsCount = new Dictionary<int,int>();
            var remainingAmount = amount;

            foreach(int denomination in denominations_)
            {
                while(remainingAmount >= denomination)
                { 
                    remainingAmount -= denomination;
                    if(denominationsCount.Keys.Any(x=>x == denomination))
                        denominationsCount[denomination]++;
                    else 
                        denominationsCount.Add(denomination,1);
                }
            }
            if (remainingAmount > 0) throw new Exception("There are no denominations to cover the whole amount.");
            return denominationsCount;
        }
    }
}