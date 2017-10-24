using System;
using AkkaPayroll.Client.ServiceCharge.Posting;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace AkkaPayroll.Client.Tests.ServiceCharge.Posting
{
	public class PostServiceChargeCommandParserTests
	{
		[Theory, AutoData]
		public void ShouldRecognizePostServiceChargeCommand(int memberId, decimal amount)
		{
			var expectedPostServiceChargeCommand = new PostServiceChargeCommand(memberId, amount);
			var command = $"ServiceCharge {memberId} {amount}";

			var postServiceChargeCommand = PostServiceChargeCommandParser.Parse(command);

			postServiceChargeCommand.Should().Be(expectedPostServiceChargeCommand);
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