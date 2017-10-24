using System;

namespace AkkaPayroll.Client.TimeCard.Adding
{
	public class AddTimeCardCommandStructureException : Exception
	{
		private const string ErrorMessage = "Inappropriate command structure. The required format is: \"TimeCard <empId> <date> <hours>\".";

		public AddTimeCardCommandStructureException() : base(ErrorMessage) {}

		public AddTimeCardCommandStructureException(Exception innerException) : base(ErrorMessage, innerException) {}
	}
}