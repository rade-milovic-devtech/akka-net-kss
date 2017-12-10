using System;
using AkkaPayroll.Client.Employee.Changing;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace AkkaPayroll.Client.Tests.Employee.Changing
{
    public class ChangeEmployeePaymentTypeToDirectCommandParserTests
    {
        [Theory, AutoData]
        public void ShouldRecognizeChangeEmployeePaymentTypeToDirectCommand(int id, string bank, string account)
        {
            var expectedChangeEmployeePaymentTypeToDirectCommand = new ChangeEmployeePaymentTypeToDirectCommand(id, bank, account);
            var command = $"ChgEmp {id} Direct \"{bank}\" \"{account}\"";

            var changeEmployeePaymentTypeToDirectCommand = ChangeEmployeePaymentTypeToDirectCommandParser.Parse(command);

            changeEmployeePaymentTypeToDirectCommand.Should().Be(expectedChangeEmployeePaymentTypeToDirectCommand);
        }
        
        [Theory]
        [InlineData("ChgEmp")]
        [InlineData("ChgEmp 1")]
        [InlineData("ChgEmp 1 Direct")]
        [InlineData("ChgEmp 1 Direct TestBank")]
        [InlineData("ChgEmp a Direct TestBank TestAccount")]
        [InlineData("ChgEmp 1 Direct \"Test Bank\" \"Test Account\" 1")]
        [InlineData("ChgEmp 1 Bla \"Test Bank\" \"Test Account\"")]
        public void ShouldErrorWhenCommandStructureIsInappropriate(string command)
        {
            Action action = () => ChangeEmployeePaymentTypeToDirectCommandParser.Parse(command);

            action.ShouldThrow<ChangeEmployeePaymentTypeToDirectCommandStructureException>();
        }
    }
}