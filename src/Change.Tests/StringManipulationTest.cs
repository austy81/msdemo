using Xunit; 
using msdemo;

namespace msdemotest
{
    public class StringManipulationTests
    {
        [Theory]
        [InlineData("ABC",1,"CAB")]
        public void ShiftRight(string input, int shift, string expectedOutput) 
        {
            var sm = new StringManipulation(input);
            Assert.Equal(sm >> shift,expectedOutput);
        }
    }
}
