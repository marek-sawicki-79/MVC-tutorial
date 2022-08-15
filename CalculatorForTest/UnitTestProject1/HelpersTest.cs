using System;
using System.Collections.Generic;
using System.Globalization;
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

        [Theory]
        [MemberData(nameof(HelpersData))]
        public void FormatDateTime_WithProperParameters_ReturnsString(DateTime date, string format,
            CultureInfo cultureInfo, string expected)
        {
            string result = Helpers.ConvertDateTimeToString(date, format, cultureInfo);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> HelpersData =>
            new List<object[]>
            {
                new object[]
                    { new DateTime(1999, 03, 23), "dd-MM-yyyy", CultureInfo.GetCultureInfo("en-US"), "23-03-1999" },
                new object[]
                {
                    new DateTime(1999, 08, 09), "dd MMMM yyyy", CultureInfo.GetCultureInfo("pl-PL"), "09 sierpnia 1999"
                },
                new object[] { new DateTime(2012, 03, 19), "ddMMM", CultureInfo.GetCultureInfo("en-US"), "19Mar" },
            };
    }
}
