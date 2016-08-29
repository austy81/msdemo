using System; 
using Xunit; 
using msdemo;

namespace msdemotest
{
    public class ChangeTest
    {
        [Theory]
        [InlineData(0,0)]
        [InlineData(1,1)]
        [InlineData(10,1)]
        [InlineData(100,1)]
        [InlineData(101,2)]
        [InlineData(105,2)]
        [InlineData(55,2)]
        [InlineData(200,2)]
        [InlineData(2,2)]
        [InlineData(205,3)]
        [InlineData(999,17)] //9x100, 1x50, 2x20, 1x5, 4x1 = 17
        [InlineData(1000000,10000)]
        [InlineData(1000000000,10000000)]
        public void MakeChangeReturnsCorrectNumberOfBills(int amount, int bills)
        {
            Change _change = new Change(new int[] {100,50,20,10,5,1});
            int result = _change.MakeChange(amount);
            
            Assert.Equal(result, bills);
        }

        [Theory]
        [InlineData(0,0)]
        [InlineData(1,1)]
        [InlineData(10,1)]
        [InlineData(100,1)]
        [InlineData(101,2)]
        [InlineData(105,2)]
        [InlineData(55,2)]
        [InlineData(200,2)]
        [InlineData(2,2)]
        [InlineData(205,3)]
        [InlineData(999,17)] //9x100, 1x50, 2x20, 1x5, 4x1 = 17
        [InlineData(1000000,10000)]
        [InlineData(1000000000,10000000)]
        public void MakeChangeUnsortedDenominations(int amount, int bills)
        {
            Change _change = new Change(new int[] {20,50,1,100,10,5});
            int result = _change.MakeChange(amount);

            Assert.Equal(result, bills);
        }

        [Theory]
        [InlineData(1,0,1)]
        [InlineData(6,1,1)]
        [InlineData(104,1,4)]
        public void MakeChangeThrowsExceptionNotSuitableDenominations(int amount,int resultBills, int remainingAmount)
        {
            Change _change = new Change(new int[] {100,50,20,10,5}); //Missing denomination 1

            Exception ex = Assert.Throws<ArgumentException>(() => _change.MakeChange(amount));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal($"There are no suitable denominations to cover the whole amount. It is possible to use {resultBills} bills and it remains amount {remainingAmount} which can not be covered by current denominations.", ex.Message);
        }

        [Theory]
        [InlineData()]
        public void MakeChangeThrowsExceptionNoDenominations()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new Change(new int[] {}));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal($"At least one denomination is needed.", ex.Message);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-42)]
        public void MakeChangeThrowsExceptionForNegativeAmount(int amount)
        {
            Change _change = new Change(new int[] {100,50,20,10,5,1});

            Exception ex = Assert.Throws<ArgumentException>(() => _change.MakeChange(amount));
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal("Negative amounts can not be changed.", ex.Message);
        }
    }
}