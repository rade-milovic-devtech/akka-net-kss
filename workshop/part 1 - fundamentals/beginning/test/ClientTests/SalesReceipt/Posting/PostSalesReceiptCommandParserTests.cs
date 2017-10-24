using System;
using AkkaPayroll.Client.SalesReceipt.Posting;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace AkkaPayroll.Client.Tests.SalesReceipt.Posting
{
	public class PostSalesReceiptCommandParserTests
	{
		[Theory, AutoData]
		public void ShouldRecognizePostSalesReceiptCommand(int employeeId, DateTime date, decimal amount)
		{
			var expectedPostSalesReceiptCommand = new PostSalesReceiptCommand(employeeId, date.Date, amount);
			var command = $"SalesReceipt {employeeId} {date:dd-MM-yyyy} {amount}";

			var postSalesReceiptCommand = PostSalesReceiptCommandParser.Parse(command);

			postSalesReceiptCommand.Should().Be(expectedPostSalesReceiptCommand);
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
			Action commandExecutor = () => PostSalesReceiptCommandParser.Parse(command);

			commandExecutor.ShouldThrow<PostSalesReceiptCommandStructureException>();
		}
	}
}