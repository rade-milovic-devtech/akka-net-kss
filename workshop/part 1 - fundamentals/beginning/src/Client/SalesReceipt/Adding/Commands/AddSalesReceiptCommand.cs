using System;

namespace AkkaPayroll.Client.SalesReceipt.Adding.Commands
{
	public class AddSalesReceiptCommand
	{
		private int employeeId;
		private DateTime date;
		private decimal amount;

		public AddSalesReceiptCommand(int employeeId, DateTime date, decimal amount)
		{
			this.employeeId = employeeId;
			this.date = date;
			this.amount = amount;
		}

		public override bool Equals(object obj)
		{
			var addSalesReceiptCommand = obj as AddSalesReceiptCommand;

			if (ReferenceEquals(addSalesReceiptCommand, null)) return false;

			return employeeId == addSalesReceiptCommand.employeeId
				&& date == addSalesReceiptCommand.date
				&& amount == addSalesReceiptCommand.amount;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = employeeId.GetHashCode();
				hashCode = (hashCode * 397) ^ date.GetHashCode();
				hashCode = (hashCode * 397) ^ amount.GetHashCode();

				return hashCode;
			}
		}

		public override string ToString() =>
			$"{nameof(AddSalesReceiptCommand)} {{ {nameof(employeeId)}: {employeeId}, {nameof(date)}: {date}, {nameof(amount)}: {amount} }}";
	}
}