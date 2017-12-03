using System;

namespace AkkaPayroll.Client.Employee.Changing
{
    public class ConvertEmployeeToHourlyCommandStructureException : Exception
    {
        private const string ErrorMessage = "Inappropriate command structure. The required format is: \"ChgEmp <empId> Hourly \"<hourlyRate>\"\".";

        public ConvertEmployeeToHourlyCommandStructureException() : base(ErrorMessage) { }

        public ConvertEmployeeToHourlyCommandStructureException(Exception innerException) : base(ErrorMessage, innerException) { }
    }
}