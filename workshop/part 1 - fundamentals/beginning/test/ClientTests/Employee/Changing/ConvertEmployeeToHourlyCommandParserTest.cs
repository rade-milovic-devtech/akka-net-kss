using System;
using AkkaPayroll.Client.Employee.Changing;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace AkkaPayroll.Client.Tests.Employee.Changing
{
    public class ConvertEmployeeToHourlyCommandParserTest
    {
        [Theory, AutoData]
        public void ShouldRecognizeConvertEmployeeToHourlyCommand(int id, decimal hourlyRate)
        {
            var expectedConvertEmployeeToHourlyCommand = new ConvertEmployeeToHourlyCommand(id, hourlyRate);
            var command = $"ChgEmp {id} Hourly {hourlyRate}";

            var convertEmployeeToHourlyCommand = ConvertEmployeeToHourlyCommandParser.Parse(command);

            convertEmployeeToHourlyCommand.Should().Be(expectedConvertEmployeeToHourlyCommand);
        }

        [Theory]
        [InlineData("ChgEmp")]
        [InlineData("ChgEmp 1")]
        [InlineData("ChgEmp 1 Hourly")]
        [InlineData("ChgEmp a Hourly 1.2")]
        [InlineData("ChgEmp 1 Hourly a")]
        [InlineData("ChgEmp 1 Hourly 1.2 a")]
        [InlineData("ChgEmp 1 Bla 1.2")]
        public void ShouldErrorWhenCommandStructureIsInappropriate(string command)
        {
            Action action = () => ConvertEmployeeToHourlyCommandParser.Parse(command);
            
            action.ShouldThrow<ConvertEmployeeToHourlyCommandStructureException>();
        }
    }
}