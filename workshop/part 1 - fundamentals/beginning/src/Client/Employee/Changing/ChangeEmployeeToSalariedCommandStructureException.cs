using System;

namespace AkkaPayroll.Client.Employee.Changing
{
    public class ChangeEmployeeToSalariedCommandStructureException : Exception
    {
        private const string ErrorMessage = "Inappropriate command structure. The required format is: \"ChgEmp <empId> Salaried <monthlySalary>\".";

        public ChangeEmployeeToSalariedCommandStructureException() : base(ErrorMessage) { }

        public ChangeEmployeeToSalariedCommandStructureException(Exception innerException) : base(ErrorMessage, innerException) { }
    }
}