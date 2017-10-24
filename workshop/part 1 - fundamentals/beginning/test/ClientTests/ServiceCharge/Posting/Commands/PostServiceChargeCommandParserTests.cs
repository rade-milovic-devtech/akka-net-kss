using System;
using AkkaPayroll.Client.ServiceCharge.Posting;
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

		[Theory]
		[InlineData("ServiceCharge")]
		[InlineData("ServiceCharge 1")]
		[InlineData("ServiceCharge a 20.00")]
		[InlineData("ServiceCharge 1 a")]
		[InlineData("ServiceCharge 1 20.20 a")]
		public void ShouldErrorWhenCommandStructureIsInappropriate(string command)
		{
			Action commandExecutor = () => PostServiceChargeCommandParser.Parse(command);

			commandExecutor.ShouldThrow<PostServiceChargeCommandStructureException>();
		}
	}
}