using System;

namespace AkkaPayroll.Client.SalesReceipt.Posting
{
	public class PostSalesReceiptCommand
	{
		public PostSalesReceiptCommand(int employeeId, DateTime date, decimal amount)
		{
			EmployeeId = employeeId;
			Date = date;
			Amount = amount;
		}

		public int EmployeeId { get; }
		public DateTime Date { get; }
		public decimal Amount { get; }

		public override bool Equals(object obj)
		{
			var postSalesReceiptCommand = obj as PostSalesReceiptCommand;

			if (ReferenceEquals(postSalesReceiptCommand, null)) return false;

			return EmployeeId == postSalesReceiptCommand.EmployeeId
				&& Date == postSalesReceiptCommand.Date
				&& Amount == postSalesReceiptCommand.Amount;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = EmployeeId.GetHashCode();
				hashCode = (hashCode * 397) ^ Date.GetHashCode();
				hashCode = (hashCode * 397) ^ Amount.GetHashCode();

				return hashCode;
			}
		}

		public override string ToString() =>
			$"{nameof(PostSalesReceiptCommand)} {{ {nameof(EmployeeId)}: {EmployeeId}, {nameof(Date)}: {Date}, {nameof(Amount)}: {Amount} }}";
	}
}