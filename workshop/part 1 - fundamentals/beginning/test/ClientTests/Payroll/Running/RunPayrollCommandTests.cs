using System;
using AkkaPayroll.Client.Payroll.Running;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace AkkaPayroll.Client.Tests.Payroll.Running
{
    public class RunPayrollCommandTests
    {
        [Theory, AutoData]
        public void ShouldRecognizeRunPayrollCommand(DateTime date)
        {
            var expectedRunPayrollCommand = new RunPayrollCommand(date.Date);
            var command = $"Payday {date:dd-MM-yyyy}";

            var runPayrollCommand = RunPayrollCommandParser.Parse(command);

            runPayrollCommand.Should().Be(expectedRunPayrollCommand);
        }
        
        [Theory]
        [InlineData("Payday")]
        [InlineData("Payday 1-2-201a")]
        [InlineData("Payday 1-2-2012 a")]
        public void ShouldErrorWhenCommandStructureIsInappropriate(string command)
        {
            Action commandExecutor = () => RunPayrollCommandParser.Parse(command);

            commandExecutor.ShouldThrow<RunPayrollCommandStructureException>();
        }
    }
}