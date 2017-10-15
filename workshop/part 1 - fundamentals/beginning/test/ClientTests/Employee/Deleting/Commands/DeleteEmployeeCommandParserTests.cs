using System;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace AkkaPayroll.Client.Employee.Deleting.Commands
{
	public class DeleteEmployeeCommandParserTests
	{
		[Theory, AutoData]
		public void ShouldRecognizeDeleteEmployeeCommand(int id)
		{
			var expectedDeleteEmployeeCommand = new DeleteEmployeeCommand(id);
			var command = $"DelEmp {id}";

			var addEmployeeCommand = DeleteEmployeeCommandParser.Parse(command);

			addEmployeeCommand.Should().Be(expectedDeleteEmployeeCommand);
		}

		[Theory]
		[InlineData("DelEmp")]
		[InlineData("DelEmp a")]
		[InlineData("DelEmp 1 a")]
		public void ShouldErrorWhenCommandStructureIsInappropriate(string command)
		{
			Action commandExecutor = () => DeleteEmployeeCommandParser.Parse(command);

			commandExecutor.ShouldThrow<DeleteEmployeeCommandStructureException>();
		}
	}
}