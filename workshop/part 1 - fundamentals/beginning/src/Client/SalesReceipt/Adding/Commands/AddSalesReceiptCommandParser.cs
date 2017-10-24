using System;
using System.Linq;
using AkkaPayroll.Client.Common;

namespace AkkaPayroll.Client.SalesReceipt.Adding.Commands
{
	public static class AddSalesReceiptCommandParser
	{
		public static AddSalesReceiptCommand Parse(string command)
		{
			var arguments = GetArgumentsFor(command);

			Validate(arguments);

			try
			{
				var employeeId = GetEmployeeIdFor(arguments);
				var date = GetDateFor(arguments);
				var amount = GetAmountFor(arguments);

				return new AddSalesReceiptCommand(employeeId, date, amount);
			}
			catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
			{
				throw new AddSalesReceiptCommandStructureException(ex);
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
				throw new AddSalesReceiptCommandStructureException();
		}

		private static int GetEmployeeIdFor(string[] arguments) => int.Parse(arguments[0]);

		private static DateTime GetDateFor(string[] arguments) => DateParser.Parse(arguments[1]);

		private static decimal GetAmountFor(string[] arguments) => decimal.Parse(arguments[2]);
	}
}