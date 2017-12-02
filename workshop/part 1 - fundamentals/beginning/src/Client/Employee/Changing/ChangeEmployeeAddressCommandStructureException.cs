using System;

namespace AkkaPayroll.Client.Employee.Changing
{
    public class ChangeEmployeeAddressCommandStructureException : Exception
    {
        private const string ErrorMessage = "Inappropriate command structure. The required format is: \"ChgEmp <empId> Address \"<address>\"\".";

        public ChangeEmployeeAddressCommandStructureException() : base(ErrorMessage) { }

        public ChangeEmployeeAddressCommandStructureException(Exception innerException) : base(ErrorMessage, innerException) { }
    }
}