using System.Collections;
using FluentAssertions;
using Xunit;

namespace CalculatorForTest.Tests
{
    public class CalculatorTests
    {
        //private readonly Calculator _calculator;

        //private CalculatorTests()
        //{
        //    _calculator = new();
        //}

        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(4, 5, 9)]
        [InlineData(4.5, 1.5, 6)]    
        
        public void Add_WithTwoNumbers_ReturnsProperValue(double valueA, double valueB, double expectedResult)
        {
            Calculator calculator = new();
            //act
            double result = calculator.Add(valueA, valueB);
            //assert
            //Assert.Equal(expectedResult, result);
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(8, 3, 5)]
        [InlineData(14, 5, 9)]
        [InlineData(16, 7, 9)]
        
        public void Substract_WithTwoNumbers_ReturnsProperValue(double valueA, double valueB, double expected)
        {
            Calculator calculator = new();
            //act
            double result = calculator.Substract(valueA, valueB);
            //assert
            //Assert.Equal(expected, result);
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Multiply_WithTwoNumbers_ReturnsProperValue(double valueA, double valueB, double expected)
        {
            Calculator calculator = new();
            //act
            double result = calculator.Multiply(valueA, valueB);
            //assert
            //Assert.Equal(expected, result);
            result.Should().Be(expected);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { 1, 2, 2 },
                new object[] { 10, 1.5, 15 },
                
                new object[] { 6, 3, 18 }
            };

        [Theory]
        [ClassData(typeof(CalculatorTestData))]
        public void Divide_WithTwoNumbers_ReturnsProperValue(double valueA, double valueB, double expected)
        {
            Calculator calculator = new();
            //act
            double result = calculator.Divide(valueA, valueB);
            //assert
            //Assert.Equal(expected, result);
            result.Should().Be(expected);
        }

        [Fact]
        public void Divide_WhenDividerIsZero_ThrowsArgumentExeption()
        {
            Calculator calculator = new();
            Assert.Throws<ArgumentException>(() => calculator.Divide(4, 0));
            
        }

    }

    public class CalculatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 2, 0.5 };
            yield return new object[] { 10, 5, 2 };
            
            yield return new object[] { 100, 10, 10};
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}