using System;

namespace AkkaPayroll.Client.TimeCard.Posting
{
	public class PostTimeCardCommandStructureException : Exception
	{
		private const string ErrorMessage = "Inappropriate command structure. The required format is: \"TimeCard <empId> <date> <hours>\".";

		public PostTimeCardCommandStructureException() : base(ErrorMessage) {}

		public PostTimeCardCommandStructureException(Exception innerException) : base(ErrorMessage, innerException) {}
	}
}