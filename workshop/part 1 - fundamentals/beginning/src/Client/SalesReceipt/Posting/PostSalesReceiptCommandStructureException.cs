using System;

namespace AkkaPayroll.Client.SalesReceipt.Posting
{
	public class PostSalesReceiptCommandStructureException : Exception
	{
		private const string ErrorMessage = "Inappropriate command structure. The required format is: \"SalesReceipt <empId> <date> <amount>\".";

		public PostSalesReceiptCommandStructureException() : base(ErrorMessage) {}

		public PostSalesReceiptCommandStructureException(Exception innerException) : base(ErrorMessage, innerException) {}
	}
}