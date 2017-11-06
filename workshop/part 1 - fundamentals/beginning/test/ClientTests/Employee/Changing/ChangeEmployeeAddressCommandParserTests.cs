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
	}
}