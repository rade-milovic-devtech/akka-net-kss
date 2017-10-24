using System;
using AkkaPayroll.Client.SalesReceipt.Adding.Commands;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace AkkaPayroll.Client.Tests.SalesReceipt.Adding.Commands
{
    public class AddSalesReceiptCommandParserTests
    {
        [Theory, AutoData]
        public void ShouldRecognizeAddSalesReceiptCommand(int employeeId, DateTime date, decimal amount)
        {
            var expectedAddTimeCardCommand = new AddSalesReceiptCommand(employeeId, date.Date, amount);
            var command = $"SalesReceipt {employeeId} {date.ToString("dd-MM-yyyy")} {amount}";

            var addTimeCardCommand = AddSalesReceiptCommandParser.Parse(command);

            addTimeCardCommand.Should().Be(expectedAddTimeCardCommand);
        }
    }
}