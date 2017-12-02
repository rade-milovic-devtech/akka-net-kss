using System;
using AkkaPayroll.Client.Employee.Changing;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace AkkaPayroll.Client.Tests.Employee.Changing
{
	public class ChangeEmployeeAddressCommandParserTests
	{
		[Theory, AutoData]
		public void ShouldRecognizeChangeEmployeeAddressCommand(int id, string address)
		{
			var expectedChangeEmployeeAddressCommand = new ChangeEmployeeAddressCommand(id, address);
			var command = $"ChgEmp {id} Address \"{address}\"";

			var changeEmployeeAddressCommand = ChangeEmployeeAddressCommandParser.Parse(command);

			changeEmployeeAddressCommand.Should().Be(expectedChangeEmployeeAddressCommand);
		}

		[Theory]
		[InlineData("ChgEmp")]
		[InlineData("ChgEmp 1")]
		[InlineData("ChgEmp 1 Address")]
		[InlineData("ChgEmp a Address \"Some Street\"")]
		[InlineData("ChgEmp 1 Address Street")]
		[InlineData("ChgEmp 1 Address \"Some Street\" 1")]
		[InlineData("ChgEmp 1 Bla \"Some Street\"")]
		public void ShouldErrorWhenCommandStructureIsInappropriate(string command)
		{
			Action action = () => ChangeEmployeeAddressCommandParser.Parse(command);

			action.ShouldThrow<ChangeEmployeeAddressCommandStructureException>();
		}
	}
}