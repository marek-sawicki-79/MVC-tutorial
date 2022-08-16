using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorForTest.Logs;
using FluentAssertions;

namespace CalculatorForTest.Tests
{
    public class LogManagerTests
    {
        [Fact]
        public void LoadLogs_WhenReadWriteLogLoadsLogs_ListNotEmpty()
        {
            LogManager logManager = new(new ReadWriteLogFake());
            logManager.LoadLogs("fakepath");
            logManager.Logs.Should().NotBeEmpty();
        }

        [Fact]
        public void AddLogs_WithMessage_LogAdded()
        {
            LogManager logManager = new(new ReadWriteLogFake());
            logManager.AddLog("testmessage");
            logManager.Logs.Count.Should().Be(1);
        }
    }
}
