using System.Collections.Generic;
using System.Linq;
using System;

namespace msdemo
{
    public class Change
    {
        IEnumerable<int> denominations_;
        public Change (IEnumerable<int> denominations) {
            if(denominations.Count() < 1) throw new ArgumentException("At least one denomination is needed.");
            denominations_ = denominations.OrderByDescending(x=>x);
        }
        public int MakeChange(int amount)
        {
            if(amount < 0) throw new ArgumentException("Negative amounts can not be changed.");
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
            if (remainingAmount > 0) throw new ArgumentException($"There are no suitable denominations to cover the whole amount. It is possible to use {denominationsCount.Sum(x=>x.Value)} bills and it remains amount {remainingAmount} which can not be covered by current denominations.");
            return denominationsCount;
        }
    }
}