using System;
using AkkaPayroll.Client.TimeCard.Posting;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace AkkaPayroll.Client.Tests.TimeCard.Posting
{
	public class PostTimeCardCommandParserTests
	{
		[Theory, AutoData]
		public void ShouldRecognizePostTimeCardCommand(int employeeId, DateTime date, int hours)
		{
			var expectedPostTimeCardCommand = new PostTimeCardCommand(employeeId, date.Date, hours);
			var command = $"TimeCard {employeeId} {date:dd-MM-yyyy} {hours}";

			var postTimeCardCommand = PostTimeCardCommandParser.Parse(command);

			postTimeCardCommand.Should().Be(expectedPostTimeCardCommand);
		}

		[Theory]
		[InlineData("TimeCard")]
		[InlineData("TimeCard 1")]
		[InlineData("TimeCard 1 1-2-2012")]
		[InlineData("TimeCard a 1-2-2012 2")]
		[InlineData("TimeCard 1 1-2-201a 2")]
		[InlineData("TimeCard 1 1-2-2012 a")]
		[InlineData("TimeCard 1 1-2-2012 2 a")]
		public void ShouldErrorWhenCommandStructureIsInappropriate(string command)
		{
			Action commandExecutor = () => PostTimeCardCommandParser.Parse(command);

			commandExecutor.ShouldThrow<PostTimeCardCommandStructureException>();
		}
	}
}
