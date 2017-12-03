using System;
using AkkaPayroll.Client.Employee.Changing;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace AkkaPayroll.Client.Tests.Employee.Changing
{
    public class ChangeEmployeePaymentTypeToHoldCommandParserTests
    {
        [Theory, AutoData]
        public void ShouldRecognizeChangeEmployeePaymentTypeToHoldCommand(int id)
        {
            var expectedChangeEmployeePaymentTypeToHoldCommand = new ChangeEmployeePaymentTypeToHoldCommand(id);
            var command = $"ChgEmp {id} Hold";

            var changeEmployeePaymentTypeToHoldCommand = ChangeEmployeePaymentTypeToHoldCommandParser.Parse(command);

            changeEmployeePaymentTypeToHoldCommand.Should().Be(expectedChangeEmployeePaymentTypeToHoldCommand);
        }
        
        [Theory]
        [InlineData("ChgEmp")]
        [InlineData("ChgEmp 1")]
        [InlineData("ChgEmp a Hold")]
        [InlineData("ChgEmp 1 Hold 1")]
        [InlineData("ChgEmp 1 Bla")]
        public void ShouldErrorWhenCommandStructureIsInappropriate(string command)
        {
            Action action = () => ChangeEmployeePaymentTypeToHoldCommandParser.Parse(command);

            action.ShouldThrow<ChangeEmployeePaymentTypeToHoldCommandStructureException>();
        }
    }
}