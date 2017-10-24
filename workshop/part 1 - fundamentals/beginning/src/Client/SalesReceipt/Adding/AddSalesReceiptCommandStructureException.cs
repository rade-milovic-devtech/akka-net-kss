using System;

namespace AkkaPayroll.Client.SalesReceipt.Adding
{
	public class AddSalesReceiptCommandStructureException : Exception
	{
		private const string ErrorMessage = "Inappropriate command structure. The required format is: \"SalesReceipt <empId> <date> <amount>\".";

		public AddSalesReceiptCommandStructureException() : base(ErrorMessage) {}

		public AddSalesReceiptCommandStructureException(Exception innerException) : base(ErrorMessage, innerException) {}
	}
}