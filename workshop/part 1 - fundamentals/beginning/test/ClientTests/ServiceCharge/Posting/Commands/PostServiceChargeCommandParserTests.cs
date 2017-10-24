using AkkaPayroll.Client.ServiceCharge.Posting.Commands;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace AkkaPayroll.Client.Tests.ServiceCharge.Posting.Commands
{
	public class PostServiceChargeCommandParserTests
	{
		[Theory, AutoData]
		public void ShouldRecognizePostServiceChargeCommand(int memberId, decimal amount)
		{
			var expectedPostServiceChargeCommand = new PostServiceChargeCommand(memberId, amount);
			var command = $"ServiceCharge {memberId} {amount}";

			var addTimeCardCommand = PostServiceChargeCommandParser.Parse(command);

			addTimeCardCommand.Should().Be(expectedPostServiceChargeCommand);
		}
	}
}