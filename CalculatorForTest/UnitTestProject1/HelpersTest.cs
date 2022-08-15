using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CalculatorForTest.Tests
{
    public class HelpersTest
    {
        [Theory]
        [InlineData("Jojo", "Oponiarz", "Jojo\tOponiarz")]
        public void BuildLogMessage_WithTwoStrings_ReturnsCombinedString(string a, string b, string expected)
        {
            string result = Helpers.BuildLogMessage(a, b);
            Assert.Equal(expected, result);
        }
    }
}
