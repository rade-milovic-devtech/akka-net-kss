using System;

namespace AkkaPayroll.Client.Employee.Changing
{
    public class ChangeEmployeePaymentTypeToMailCommandStructureException : Exception
    {
        private const string ErrorMessage = "Inappropriate command structure. The required format is: \"ChgEmp <empId> Mail \"<address>\"\".";

        public ChangeEmployeePaymentTypeToMailCommandStructureException() : base(ErrorMessage) { }

        public ChangeEmployeePaymentTypeToMailCommandStructureException(Exception innerException) : base(ErrorMessage, innerException) { }
    }
}