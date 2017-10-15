using System;

namespace AkkaPayroll.Client.Employee.Adding
{
	public class AddEmployeeCommandStructureException : Exception
	{
		private const string ErrorMessage = "Inappropriate command structure. The required format is: \"AddEmp <empId> \"<name>\" \"<address>\" H | S | C <hourlyRate> | <monthlySalary> | <monthlySalary> <commissionRate>\".";

		public AddEmployeeCommandStructureException() : base(ErrorMessage) {}

		public AddEmployeeCommandStructureException(Exception innerException) : base(ErrorMessage, innerException) {}
	}
}