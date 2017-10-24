using System;
using AkkaPayroll.Client.Employee.Deleting;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace AkkaPayroll.Client.Tests.Employee.Deleting
{
	public class DeleteEmployeeCommandParserTests
	{
		[Theory, AutoData]
		public void ShouldRecognizeDeleteEmployeeCommand(int id)
		{
			var expectedDeleteEmployeeCommand = new DeleteEmployeeCommand(id);
			var command = $"DelEmp {id}";

			var deleteEmployeeCommand = DeleteEmployeeCommandParser.Parse(command);

			deleteEmployeeCommand.Should().Be(expectedDeleteEmployeeCommand);
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