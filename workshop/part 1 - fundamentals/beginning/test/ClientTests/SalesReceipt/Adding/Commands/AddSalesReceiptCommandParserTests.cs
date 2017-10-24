using System;
using AkkaPayroll.Client.SalesReceipt.Adding;
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
			var command = $"SalesReceipt {employeeId} {date:dd-MM-yyyy} {amount}";

			var addTimeCardCommand = AddSalesReceiptCommandParser.Parse(command);

			addTimeCardCommand.Should().Be(expectedAddTimeCardCommand);
		}

		[Theory]
		[InlineData("SalesReceipt")]
		[InlineData("SalesReceipt 1")]
		[InlineData("SalesReceipt 1 1-2-2012")]
		[InlineData("SalesReceipt a 1-2-2012 200.20")]
		[InlineData("SalesReceipt 1 1-2-201a 200.20")]
		[InlineData("SalesReceipt 1 1-2-2012 a")]
		[InlineData("SalesReceipt 1 1-2-2012 200.20 a")]
		public void ShouldErrorWhenCommandStructureIsInappropriate(string command)
		{
			Action commandExecutor = () => AddSalesReceiptCommandParser.Parse(command);

			commandExecutor.ShouldThrow<AddSalesReceiptCommandStructureException>();
		}
	}
}