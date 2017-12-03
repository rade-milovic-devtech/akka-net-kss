using System;
using AkkaPayroll.Client.Employee.Changing;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace AkkaPayroll.Client.Tests.Employee.Changing
{
    public class ChangeEmployeeToHourlyCommandParserTests
    {
        [Theory, AutoData]
        public void ShouldRecognizeChangeEmployeeToHourlyCommand(int id, decimal hourlyRate)
        {
            var expectedChangeEmployeeToHourlyCommand = new ChangeEmployeeToHourlyCommand(id, hourlyRate);
            var command = $"ChgEmp {id} Hourly {hourlyRate}";

            var changeEmployeeToHourlyCommand = ChangeEmployeeToHourlyCommandParser.Parse(command);

            changeEmployeeToHourlyCommand.Should().Be(expectedChangeEmployeeToHourlyCommand);
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
            Action action = () => ChangeEmployeeToHourlyCommandParser.Parse(command);
            
            action.ShouldThrow<ChangeEmployeeToHourlyCommandStructureException>();
        }
    }
}