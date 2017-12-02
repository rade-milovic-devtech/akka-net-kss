using System;

namespace AkkaPayroll.Client.Employee.Changing
{
	public class ChangeEmployeeNameCommandStructureException : Exception
	{
		private const string ErrorMessage = "Inappropriate command structure. The required format is: \"ChgEmp <empId> Name \"<name>\"\".";

		public ChangeEmployeeNameCommandStructureException() : base(ErrorMessage) { }

		public ChangeEmployeeNameCommandStructureException(Exception innerException) : base(ErrorMessage, innerException) { }
	}
}