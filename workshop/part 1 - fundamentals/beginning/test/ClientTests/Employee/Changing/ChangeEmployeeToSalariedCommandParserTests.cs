using System;
using AkkaPayroll.Client.Employee.Changing;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace AkkaPayroll.Client.Tests.Employee.Changing
{
    public class ChangeEmployeeToSalariedCommandParserTests
    {
        [Theory, AutoData]
        public void ShouldRecognizeChangeEmployeeToSalariedCommand(int id, decimal monthlySalary)
        {
            var expectedChangeEmployeeToSalariedCommand = new ChangeEmployeeToSalariedCommand(id, monthlySalary);
            var command = $"ChgEmp {id} Salaried {monthlySalary}";

            var changeEmployeeToSalariedCommand = ChangeEmployeeToSalariedCommandParser.Parse(command);

            changeEmployeeToSalariedCommand.Should().Be(expectedChangeEmployeeToSalariedCommand);
        }
        
        [Theory]
        [InlineData("ChgEmp")]
        [InlineData("ChgEmp 1")]
        [InlineData("ChgEmp 1 Salaried")]
        [InlineData("ChgEmp a Salaried 1.2")]
        [InlineData("ChgEmp 1 Salaried a")]
        [InlineData("ChgEmp 1 Salaried 1000.0 a")]
        [InlineData("ChgEmp 1 Bla 1000.0")]
        public void ShouldErrorWhenCommandStructureIsInappropriate(string command)
        {
            Action action = () => ChangeEmployeeToSalariedCommandParser.Parse(command);
            
            action.ShouldThrow<ChangeEmployeeToSalariedCommandStructureException>();
        }
    }
}