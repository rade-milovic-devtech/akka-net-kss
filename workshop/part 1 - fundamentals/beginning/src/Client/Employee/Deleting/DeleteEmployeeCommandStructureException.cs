using System;

namespace AkkaPayroll.Client.Employee.Deleting
{
	public class DeleteEmployeeCommandStructureException : Exception
	{
		private const string ErrorMessage = "Inappropriate command structure. The required format is: \"DelEmp <empId>\".";

		public DeleteEmployeeCommandStructureException() : base(ErrorMessage) {}

		public DeleteEmployeeCommandStructureException(Exception innerException) : base(ErrorMessage, innerException) {}
	}
}