using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using System;
using AkkaPayroll.Client.Employee.Changing;
using Xunit;

namespace AkkaPayroll.Client.Tests.Employee.Changing
{
	public class ChangeEmployeeNameCommandParserTests
	{
		[Theory, AutoData]
		public void ShouldRecognizeChangeEmployeeNameCommand(int id, string name)
		{
			var expectedChangeEmployeeNameCommand = new ChangeEmployeeNameCommand(id, name);
			var command = $"ChgEmp {id} Name \"{name}\"";

			var changeEmployeeNameCommand = ChangeEmployeeNameCommandParser.Parse(command);

			changeEmployeeNameCommand.Should().Be(expectedChangeEmployeeNameCommand);
		}

		[Theory]
		[InlineData("ChgEmp")]
		[InlineData("ChgEmp 1")]
		[InlineData("ChgEmp 1 Name")]
		[InlineData("ChgEmp a Name \"John Doe\"")]
		[InlineData("ChgEmp 1 Name John")]
		[InlineData("ChgEmp 1 Name \"John Doe\" 1")]
		[InlineData("ChgEmp 1 Bla \"John Doe\"")]
		public void ShouldErrorWhenCommandStructureIsInappropriate(string command)
		{
			Action action = () => ChangeEmployeeNameCommandParser.Parse(command);

			action.ShouldThrow<ChangeEmployeeCommandStructureException>();
		}
	}
}