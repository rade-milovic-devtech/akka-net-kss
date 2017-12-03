using System;

namespace AkkaPayroll.Client.Employee.Changing
{
    public class ChangeEmployeePaymentTypeToHoldCommandStructureException : Exception
    {
        private const string ErrorMessage = "Inappropriate command structure. The required format is: \"ChgEmp <empId> Hold\".";

        public ChangeEmployeePaymentTypeToHoldCommandStructureException() : base(ErrorMessage) {}

        public ChangeEmployeePaymentTypeToHoldCommandStructureException(Exception innerException) : base(ErrorMessage, innerException) {}
    }
}