using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorForTest.Logs;
using FluentAssertions;
using Xunit;

namespace CalculatorForTest.Tests
{
    public class ReadWriteLogTests : IDisposable
    {
        //private readonly ReadWriteLog _readWriteLog;

        //private ReadWriteLogTests() 
        //{
        //    _readWriteLog = new();
        //}
        public void Dispose()
        {

            File.Delete("Resources/savedlogs.txt");
        }

        [Fact]
        public void ReadAllLogs_WithProperPath_ReturnNotEmptyCollection()
        {
            ReadWriteLog readWriteLog = new();
            IEnumerable<string> result = readWriteLog.ReadLogsFromFile("Resources/logs.txt");
            //Assert.NotEmpty(result);
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void SaveLogs_WithNoEmptyList_CreatesFile()
        {
            ReadWriteLog readWriteLog = new();
            IEnumerable<string> input = new List<string>() {"test1", "test2"};
            readWriteLog.SaveLogs("Resources/savedlogs.txt", input);
            //Assert.True(File.Exists("Resources/savedlogs.txt"));
            File.Exists("Resources/savedlogs.txt").Should().BeTrue();
        }
    }
}
