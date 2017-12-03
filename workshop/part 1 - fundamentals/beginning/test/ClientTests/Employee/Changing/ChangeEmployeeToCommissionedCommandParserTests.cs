using System;
using AkkaPayroll.Client.Employee.Changing;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace AkkaPayroll.Client.Tests.Employee.Changing
{
    public class ChangeEmployeeToCommissionedCommandParserTests
    {
        [Theory, AutoData]
        public void ShouldRecognizeChangeEmployeeToCommissionedCommand(int id, decimal monthlySalary, decimal commissionRate)
        {
            var expectedChangeEmployeeToCommissionedCommand = new ChangeEmployeeToCommissionedCommand(id, monthlySalary, commissionRate);
            var command = $"ChgEmp {id} Commissioned {monthlySalary} {commissionRate}";

            var changeEmployeeToCommissionedCommand = ChangeEmployeeToCommissionedCommandParser.Parse(command);

            changeEmployeeToCommissionedCommand.Should().Be(expectedChangeEmployeeToCommissionedCommand);
        }
        
        [Theory]
        [InlineData("ChgEmp")]
        [InlineData("ChgEmp 1")]
        [InlineData("ChgEmp 1 Commissioned")]
        [InlineData("ChgEmp 1 Commissioned 1000.0")]
        [InlineData("ChgEmp a Commissioned 1000.0 1.2")]
        [InlineData("ChgEmp 1 Commissioned a 1.2")]
        [InlineData("ChgEmp 1 Commissioned 1000.0 a")]
        [InlineData("ChgEmp 1 Commissioned 1000.0 1.2 a")]
        [InlineData("ChgEmp 1 Bla 1000.0 1.2")]
        public void ShouldErrorWhenCommandStructureIsInappropriate(string command)
        {
            Action action = () => ChangeEmployeeToCommissionedCommandParser.Parse(command);
            
            action.ShouldThrow<ChangeEmployeeToCommissionedCommandStructureException>();
        }
    }
}