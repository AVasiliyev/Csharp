using Xunit;

namespace XUnitTestProject
{
    public class Test
    {
        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        public void MyFirstTheory(int value)
        {
            Assert.True(IsOdd(value));
        }

        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, 2 + 7);
        }


        bool IsOdd(int value)
        {
            return value % 2 == 1;
        }
    }
}
