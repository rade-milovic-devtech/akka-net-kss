using System;

namespace AkkaPayroll.Client.Employee.Changing
{
    public class ChangeEmployeeToHourlyCommandStructureException : Exception
    {
        private const string ErrorMessage = "Inappropriate command structure. The required format is: \"ChgEmp <empId> Hourly \"<hourlyRate>\"\".";

        public ChangeEmployeeToHourlyCommandStructureException() : base(ErrorMessage) { }

        public ChangeEmployeeToHourlyCommandStructureException(Exception innerException) : base(ErrorMessage, innerException) { }
    }
}