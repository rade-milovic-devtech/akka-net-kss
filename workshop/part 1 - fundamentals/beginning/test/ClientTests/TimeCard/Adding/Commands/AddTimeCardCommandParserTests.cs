using AkkaPayroll.Client.TimeCard.Adding.Commands;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using System;
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
    }
}
