using System;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace AkkaPayroll.Client.Employee.Adding.Commands
{
	public class AddEmployeeCommandParserTests
	{
		[Theory, AutoData]
		public void ShouldRecognizeAddHourlyEmployeeCommand(int id, string name, string address, decimal hourlyRate)
		{
			var expectedAddEmployeeCommand = new AddHourlyEmployeeCommand(id, name, address, hourlyRate);
			var command = $"AddEmp {id} \"{name}\" \"{address}\" H {hourlyRate}";

			var addEmployeeCommand = AddEmployeeCommandParser.Parse(command);

			addEmployeeCommand.Should().Be(expectedAddEmployeeCommand);
		}

		[Theory, AutoData]
		public void ShouldRecognizeAddSalariedEmployeeCommand(int id, string name, string address, decimal monthlySalary)
		{
			var expectedAddEmployeeCommand = new AddSalariedEmployeeCommand(id, name, address, monthlySalary);
			var command = $"AddEmp {id} \"{name}\" \"{address}\" S {monthlySalary}";

			var addEmployeeCommand = AddEmployeeCommandParser.Parse(command);

			addEmployeeCommand.Should().Be(expectedAddEmployeeCommand);
		}

		[Theory, AutoData]
		public void ShouldRecognizeAddCommissionedEmployeeCommand(int id, string name, string address, decimal monthlySalary, decimal commissionRate)
		{
			var expectedAddEmployeeCommand = new AddCommissionedEmployeeCommand(id, name, address, monthlySalary, commissionRate);
			var command = $"AddEmp {id} \"{name}\" \"{address}\" C {monthlySalary} {commissionRate}";

			var addEmployeeCommand = AddEmployeeCommandParser.Parse(command);

			addEmployeeCommand.Should().Be(expectedAddEmployeeCommand);
		}

		[Theory]
		[InlineData("AddEmp")]
		[InlineData("AddEmp 1 \"John Doe\"")]
		[InlineData("AddEmp a \"John Doe\" \"Some Street\" H 1.2")]
		[InlineData("AddEmp 1 \"John Doe\" H 1.2")]
		[InlineData("AddEmp 1 \"John Doe\" \"Some Street\" H")]
		[InlineData("AddEmp 1 \"John Doe\" \"Some Street\" H a")]
		[InlineData("AddEmp 1 \"John Doe\" \"Some Street\" H 1.2 a")]
		[InlineData("AddEmp 1 \"John Doe\" S 1000")]
		[InlineData("AddEmp 1 \"John Doe\" \"Some Street\" S")]
		[InlineData("AddEmp 1 \"John Doe\" \"Some Street\" S b")]
		[InlineData("AddEmp 1 \"John Doe\" \"Some Street\" S 1000 b")]
		[InlineData("AddEmp 1 \"John Doe\" C 1000 1.2")]
		[InlineData("AddEmp 1 \"John Doe\" \"Some Street\" C")]
		[InlineData("AddEmp 1 \"John Doe\" \"Some Street\" C 1000")]
		[InlineData("AddEmp 1 \"John Doe\" \"Some Street\" C c 1.2")]
		[InlineData("AddEmp 1 \"John Doe\" \"Some Street\" C 1000 c")]
		[InlineData("AddEmp 1 \"John Doe\" \"Some Street\" C c d")]
		[InlineData("AddEmp 1 \"John Doe\" \"Some Street\" C 1000 1.2 c")]
		public void ShouldErrorWhenCommandStructureIsInappropriate(string command)
		{
			Action commandExecutor = () => AddEmployeeCommandParser.Parse(command);

			commandExecutor.ShouldThrow<AddEmployeeCommandStructureException>();
		}

		[Fact]
		public void ShouldErrorWhenEmployeeTypeIsNotRecognized()
		{
			var command = "AddEmp 1 \"John Doe\" \"Some Street\" Z 1000 1.2";
			Action commandExecutor = () => AddEmployeeCommandParser.Parse(command);

			commandExecutor.ShouldThrow<AddEmployeeCommandStructureException>();
		}
	}
}