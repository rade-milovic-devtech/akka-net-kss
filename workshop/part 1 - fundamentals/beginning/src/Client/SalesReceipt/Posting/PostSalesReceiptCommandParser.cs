using System;
using System.Linq;
using AkkaPayroll.Client.Common;

namespace AkkaPayroll.Client.SalesReceipt.Posting
{
	public static class PostSalesReceiptCommandParser
	{
		public static PostSalesReceiptCommand Parse(string command)
		{
			var arguments = GetArgumentsFor(command);

			Validate(arguments);

			try
			{
				var employeeId = GetEmployeeIdFrom(arguments);
				var date = GetDateFrom(arguments);
				var amount = GetAmountFrom(arguments);

				return new PostSalesReceiptCommand(employeeId, date, amount);
			}
			catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
			{
				throw new PostSalesReceiptCommandStructureException(ex);
			}
		}

		private static string[] GetArgumentsFor(string command)
		{
			var commandTokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);;

			return commandTokens.Where(token => !string.IsNullOrWhiteSpace(token))
				.Skip(1)
				.ToArray();
		}

		private static void Validate(string[] arguments)
		{
			if (arguments.Length > 3)
				throw new PostSalesReceiptCommandStructureException();
		}

		private static int GetEmployeeIdFrom(string[] arguments) => int.Parse(arguments[0]);

		private static DateTime GetDateFrom(string[] arguments) => DateParser.Parse(arguments[1]);

		private static decimal GetAmountFrom(string[] arguments) => decimal.Parse(arguments[2]);
	}
}