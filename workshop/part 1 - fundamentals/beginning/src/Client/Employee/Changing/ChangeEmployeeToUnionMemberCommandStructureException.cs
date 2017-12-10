using System;

namespace AkkaPayroll.Client.Employee.Changing
{
    public class ChangeEmployeeToUnionMemberCommandStructureException : Exception
    {
        private const string ErrorMessage = "Inappropriate command structure. The required format is: \"ChgEmp <empId> Member <memberId> Dues <commissionRate>\".";

        public ChangeEmployeeToUnionMemberCommandStructureException() : base(ErrorMessage) { }

        public ChangeEmployeeToUnionMemberCommandStructureException(Exception innerException) : base(ErrorMessage, innerException) { }
    }
}