using Xunit; 
using msdemo;

namespace msdemotest
{
    public class StringManipulationTests
    {
        [Theory]
        [InlineData("ABC",1,"CAB")]
        [InlineData("A",10,"A")]
        [InlineData("AB",10,"AB")]
        [InlineData("AB",11,"BA")]
        [InlineData("ABC",3,"ABC")]
        public void ShiftRight(string input, int shift, string expectedOutput) 
        {
            var sm = new StringManipulation(input);
            Assert.Equal(expectedOutput, sm >> shift);
        }

        [Theory]
        [InlineData("ABC",1,"BCA")]
        [InlineData("A",10,"A")]
        [InlineData("AB",10,"AB")]
        [InlineData("AB",11,"BA")]
        [InlineData("ABC",3,"ABC")]
        [InlineData("ABC",-3,"ABC")]
        [InlineData("ABC",-1,"CAB")]
        public void ShiftLeft(string input, int shift, string expectedOutput) 
        {
            var sm = new StringManipulation(input);
            Assert.Equal(expectedOutput, sm << shift);
        }
    }
}
