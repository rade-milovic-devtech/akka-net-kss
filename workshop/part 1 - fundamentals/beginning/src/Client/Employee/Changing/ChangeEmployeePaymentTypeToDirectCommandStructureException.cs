using System;

namespace AkkaPayroll.Client.Employee.Changing
{
    public class ChangeEmployeePaymentTypeToDirectCommandStructureException : Exception
    {
        private const string ErrorMessage = "Inappropriate command structure. The required format is: \"ChgEmp <empId> Direct \"<bank>\" \"<account>\"\".";

        public ChangeEmployeePaymentTypeToDirectCommandStructureException() : base(ErrorMessage) { }

        public ChangeEmployeePaymentTypeToDirectCommandStructureException(Exception innerException) : base(ErrorMessage, innerException) { }
    }
}