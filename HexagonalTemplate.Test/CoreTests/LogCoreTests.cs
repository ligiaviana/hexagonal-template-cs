using HexagonalTemplate.Cores;
using HexagonalTemplate.Ports.Ins;
using Xunit;
using Xunit.Abstractions;
using System.IO;
using System.Text;

namespace HexagonalTemplate.Test.CoreTests
{
    public class LogCoreTests
    {
        private readonly ITestOutputHelper output;

        public LogCoreTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Log_ValidMessage_WritesToConsole()
        {
            // Arrange
            string message = "Test message";
            var logCore = new LogCore();
            var stringBuilder = new StringBuilder();
            var stringWriter = new StringWriter(stringBuilder);

            // Redirect Console output to the StringBuilder
            Console.SetOut(stringWriter);

            // Act
            logCore.Log(message);

            // Assert
            var consoleOutput = stringBuilder.ToString();
            Assert.Contains(message, consoleOutput);

            // Restore Console output
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        }
    }
}
