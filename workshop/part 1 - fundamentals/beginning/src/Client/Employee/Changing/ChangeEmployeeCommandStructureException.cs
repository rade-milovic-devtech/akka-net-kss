using System;

namespace AkkaPayroll.Client.Employee.Changing
{
	public class ChangeEmployeeCommandStructureException : Exception
	{
		private const string ErrorMessage = "Inappropriate command structure. The required format is: \"ChgEmp <empId> Name \"<name>\"\".";

		public ChangeEmployeeCommandStructureException() : base(ErrorMessage) { }

		public ChangeEmployeeCommandStructureException(Exception innerException) : base(ErrorMessage, innerException) { }
	}
}