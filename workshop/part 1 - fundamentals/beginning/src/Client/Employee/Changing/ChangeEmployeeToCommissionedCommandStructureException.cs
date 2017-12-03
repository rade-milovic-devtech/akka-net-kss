using System;

namespace AkkaPayroll.Client.Employee.Changing
{
    public class ChangeEmployeeToCommissionedCommandStructureException : Exception
    {
        private const string ErrorMessage = "Inappropriate command structure. The required format is: \"ChgEmp <empId> Commissioned <monthlySalary> <commissionRate>\".";

        public ChangeEmployeeToCommissionedCommandStructureException() : base(ErrorMessage) { }

        public ChangeEmployeeToCommissionedCommandStructureException(Exception innerException) : base(ErrorMessage, innerException) { }
    }
}