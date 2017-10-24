using AkkaPayroll.Client.TimeCard.Adding.Commands;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using System;
using AkkaPayroll.Client.TimeCard.Adding;
using Xunit;

namespace AkkaPayroll.Client.Tests.TimeCard.Adding.Commands
{
    public class AddTimeCardCommandParserTests
    {
        [Theory, AutoData]
        public void ShouldRecognizeAddTimeCardCommand(int employeeId, DateTime date, int hours)
        {
            var expectedAddTimeCardCommand = new AddTimeCardCommand(employeeId, date.Date, hours);
            var command = $"TimeCard {employeeId} {date.ToString("dd-MM-yyyy")} {hours}";

            var addTimeCardCommand = AddTimeCardCommandParser.Parse(command);

            addTimeCardCommand.Should().Be(expectedAddTimeCardCommand);
        }

        [Theory]
        [InlineData("TimeCard")]
        [InlineData("TimeCard 1")]
        [InlineData("TimeCard 1 1-2-2012")]
        [InlineData("TimeCard a 1-2-2012 2")]
        [InlineData("TimeCard 1 1-2-201a 2")]
        [InlineData("TimeCard 1 1-2-2012 a")]
        public void ShouldErrorWhenCommandStructureIsInappropriate(string command)
        {
            Action commandExecutor = () => AddTimeCardCommandParser.Parse(command);

            commandExecutor.ShouldThrow<AddTimeCardCommandStructureException>();
        }
    }
}
