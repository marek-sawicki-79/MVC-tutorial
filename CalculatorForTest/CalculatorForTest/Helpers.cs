using System.Globalization;

namespace CalculatorForTest
{
    public static class Helpers
    {
        public static string ConvertDateTimeToString(DateTime dateTime, string format, CultureInfo cultureInfo) => dateTime.ToString(format, cultureInfo);
        public static string BuildLogMessage(params string[] values) => string.Join('\t', values);
    }
}
