using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorForTest.Logs;
using Xunit;

namespace CalculatorForTest.Tests
{
    public class ReadWriteLogTests : IDisposable
    {
        private readonly ReadWriteLog _readWriteLog;

        private ReadWriteLogTests() 
        {
            _readWriteLog = new();
        }
        public void Dispose()
        {
            File.Delete("Resources/savedlogs.txt");
        }

        [Fact]
        public void ReadAllLogs_WithProperPath_ReturnNotEmptyCollection()
        {
            IEnumerable<string> result = _readWriteLog.ReadLogsFromFile("Resources/logs.txt");
            Assert.NotEmpty(result);
        }

        [Fact]
        public void SaveLogs_WithNoEmptyList_CreatesFile()
        {
            
            IEnumerable<string> input = new List<string>() {"test1", "test2"};
            _readWriteLog.SaveLogs("Resources/savedlogs.txt", input);
            Assert.True(File.Exists("Resources/savedlogs.txt"));
        }
    }
}
