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
        [InlineData(null,1,null)]
        [InlineData(null,10,null)]
        [InlineData("",1,"")]
        [InlineData("",10,"")]
        [InlineData("AB",0,"AB")]
        public void ShiftRight(string input, int shift, string expectedOutput) 
        {
            var sm = new StringManipulation(input);

            Assert.Equal(new StringManipulation(expectedOutput), sm << shift);
        }

        [Theory]
        [InlineData("ABC",1,"BCA")]
        [InlineData("A",10,"A")]
        [InlineData("AB",10,"AB")]
        [InlineData("AB",11,"BA")]
        [InlineData("ABC",3,"ABC")]
        [InlineData("ABC",-3,"ABC")]
        [InlineData("ABC",-1,"CAB")]
        [InlineData(null,1,null)]
        [InlineData(null,10,null)]
        [InlineData("",1,"")]
        [InlineData("",10,"")]
        [InlineData("AB",0,"AB")]
        public void ShiftLeft(string input, int shift, string expectedOutput) 
        {
            var sm = new StringManipulation(input);

            Assert.Equal(new StringManipulation(expectedOutput), sm >> shift);
        }

        [Theory]
        [InlineData("ABC",1,1,"ABC")]
        [InlineData("ABC",1,3,"BCA")]
        [InlineData("ABC",3,1,"CAB")]
        public void ShiftLeftAndRight(string input, int leftShift, int rightShift, string expectedOutput) 
        {
            var sm = new StringManipulation(input);
            var temp = sm >> leftShift;

            Assert.Equal(new StringManipulation(expectedOutput), sm << rightShift);
        }


        [Theory]
        [InlineData("A", "A", true)]
        [InlineData("AB", "AB", true)]
        [InlineData("~!@#$%^&*()_}{|:?><", "~!@#$%^&*()_}{|:?><", true)]
        [InlineData("A", "B", false)]
        [InlineData("A", "AA", false)]
        [InlineData("AA", "A", false)]
        [InlineData(null, "A", false)]
        [InlineData("A", null, false)]
        [InlineData(null, null, true)]
        [InlineData("", "", true)]
        public void EqualOperator(string inputA, string inputB, bool expectedResult) 
        {
            var smA = new StringManipulation(inputA);
            var smB = new StringManipulation(inputB);
            
            Assert.Equal(expectedResult, smA == smB);
        }

        [Theory]
        [InlineData("A", "A", false)]
        [InlineData("AB", "AB", false)]
        [InlineData("~!@#$%^&*()_}{|:?><", "~!@#$%^&*()_}{|:?><", false)]
        [InlineData("A", "B", true)]
        [InlineData("A", "AA", true)]
        [InlineData("A", null, true)]
        [InlineData(null, "A", true)]
        [InlineData(null, null, false)]
        [InlineData("", "", false)]
        public void NotEqualsOperator(string inputA, string inputB, bool expectedResult) 
        {
            var smA = new StringManipulation(inputA);
            var smB = new StringManipulation(inputB);
            
            Assert.Equal(expectedResult, smA != smB);
        }
    }
}
