using System;

namespace AkkaPayroll.Client.ServiceCharge.Posting
{
	public class PostServiceChargeCommandStructureException : Exception
	{
		private const string ErrorMessage = "Inappropriate command structure. The required format is: \"ServiceCharge <memberId> <amount>\".";

		public PostServiceChargeCommandStructureException() : base(ErrorMessage) {}

		public PostServiceChargeCommandStructureException(Exception innerException) : base(ErrorMessage, innerException) {}
	}
}