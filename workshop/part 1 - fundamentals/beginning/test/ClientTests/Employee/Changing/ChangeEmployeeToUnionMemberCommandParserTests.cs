using System;
using AkkaPayroll.Client.Employee.Changing;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace AkkaPayroll.Client.Tests.Employee.Changing
{
    public class ChangeEmployeeToUnionMemberCommandParserTests
    {
        [Theory, AutoData]
        public void ShouldRecognizeChangeEmployeeToUnionMemberCommand(int id, int memberId, decimal commissionRate)
        {
            var expectedChangeEmployeeToUnionMemberCommand = new ChangeEmployeeToUnionMemberCommand(id, memberId, commissionRate);
            var command = $"ChgEmp {id} Member {memberId} Dues {commissionRate}";

            var changeEmployeeToUnionMemberCommand = ChangeEmployeeToUnionMemberCommandParser.Parse(command);

            changeEmployeeToUnionMemberCommand.Should().Be(expectedChangeEmployeeToUnionMemberCommand);
        }
        
        [Theory]
        [InlineData("ChgEmp")]
        [InlineData("ChgEmp 1")]
        [InlineData("ChgEmp 1 Member")]
        [InlineData("ChgEmp 1 Member 1")]
        [InlineData("ChgEmp 1 Member 1 Dues")]
        [InlineData("ChgEmp a Member 1 Dues 1.2")]
        [InlineData("ChgEmp 1 Member a Dues 1.2")]
        [InlineData("ChgEmp 1 Member 1 Dues a")]
        [InlineData("ChgEmp 1 Bla 1 Dues 1.2")]
        [InlineData("ChgEmp 1 Member 1 Bla 1.2")]
        [InlineData("ChgEmp 1 Member 1 Dues 1.2 a")]
        public void ShouldErrorWhenCommandStructureIsInappropriate(string command)
        {
            Action action = () => ChangeEmployeeToUnionMemberCommandParser.Parse(command);
            
            action.ShouldThrow<ChangeEmployeeToUnionMemberCommandStructureException>();
        }
    }
}