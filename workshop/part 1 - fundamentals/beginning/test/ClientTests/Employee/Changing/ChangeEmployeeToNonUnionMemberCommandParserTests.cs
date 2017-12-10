using System;
using AkkaPayroll.Client.Employee.Changing;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace AkkaPayroll.Client.Tests.Employee.Changing
{
    public class ChangeEmployeeToNonUnionMemberCommandParserTests
    {
        [Theory, AutoData]
        public void ShouldRecognizeChangeEmployeeToNonUnionMemberCommand(int id)
        {
            var expectedChangeEmployeeToNonUnionMemberCommand = new ChangeEmployeeToNonUnionMemberCommand(id);
            var command = $"ChgEmp {id} NoMember";

            var changeEmployeeToNonUnionMemberCommand = ChangeEmployeeToNonUnionMemberCommandParser.Parse(command);

            changeEmployeeToNonUnionMemberCommand.Should().Be(expectedChangeEmployeeToNonUnionMemberCommand);
        }
        
        [Theory]
        [InlineData("ChgEmp")]
        [InlineData("ChgEmp 1")]
        [InlineData("ChgEmp a NoMember")]
        [InlineData("ChgEmp 1 Bla")]
        [InlineData("ChgEmp 1 NoMember 1")]
        public void ShouldErrorWhenCommandStructureIsInappropriate(string command)
        {
            Action action = () => ChangeEmployeeToNonUnionMemberCommandParser.Parse(command);
            
            action.ShouldThrow<ChangeEmployeeToNonUnionMemberCommandStructureException>();
        }
    }
}