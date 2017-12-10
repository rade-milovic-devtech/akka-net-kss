using System;

namespace AkkaPayroll.Client.Employee.Changing
{
    public class ChangeEmployeeToNonUnionMemberCommandStructureException : Exception
    {
        private const string ErrorMessage = "Inappropriate command structure. The required format is: \"ChgEmp <empId> NoMember\".";
        
        public ChangeEmployeeToNonUnionMemberCommandStructureException() : base(ErrorMessage) { }
        
        public ChangeEmployeeToNonUnionMemberCommandStructureException(Exception innerException) : base(ErrorMessage, innerException) { }
    }
}