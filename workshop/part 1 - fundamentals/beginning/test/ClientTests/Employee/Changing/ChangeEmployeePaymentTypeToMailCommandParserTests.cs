using System;
using AkkaPayroll.Client.Employee.Changing;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace AkkaPayroll.Client.Tests.Employee.Changing
{
    public class ChangeEmployeePaymentTypeToMailCommandParserTests
    {
        [Theory, AutoData]
        public void ShouldRecognizeChangeEmployeePaymentTypeToMailCommand(int id, string address)
        {
            var expectedChangeEmployeePaymentTypeToMailCommand = new ChangeEmployeePaymentTypeToMailCommand(id, address);
            var command = $"ChgEmp {id} Mail \"{address}\"";

            var changeEmployeePaymentTypeToMailCommand = ChangeEmployeePaymentTypeToMailCommandParser.Parse(command);

            changeEmployeePaymentTypeToMailCommand.Should().Be(expectedChangeEmployeePaymentTypeToMailCommand);
        }
        
        [Theory]
        [InlineData("ChgEmp")]
        [InlineData("ChgEmp 1")]
        [InlineData("ChgEmp 1 Mail")]
        [InlineData("ChgEmp a Mail \"Some Street 123\"")]
        [InlineData("ChgEmp 1 Mail Street 1")]
        [InlineData("ChgEmp 1 Bla \"Some Street 123\"")]
        public void ShouldErrorWhenCommandStructureIsInappropriate(string command)
        {
            Action action = () => ChangeEmployeePaymentTypeToMailCommandParser.Parse(command);

            action.ShouldThrow<ChangeEmployeePaymentTypeToMailCommandStructureException>();
        }
    }
}