using AkkaPayroll.Client.Commands.Employee;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace AkkaPayroll.Tests.Commands.Employee
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
	}
}