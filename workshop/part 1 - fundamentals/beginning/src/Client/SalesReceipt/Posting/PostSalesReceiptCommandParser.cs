using System;
using AkkaPayroll.Client.Common;

namespace AkkaPayroll.Client.SalesReceipt.Posting
{
	public static class PostSalesReceiptCommandParser
	{
		public static PostSalesReceiptCommand Parse(string command)
		{
			try
			{
				var arguments = CommandsArgumentsExtractor.ExtractFrom(command);

				Validate(arguments);

				return new PostSalesReceiptCommand(
					GetEmployeeIdFrom(arguments),
					GetDateFrom(arguments),
					GetAmountFrom(arguments));
			}
			catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
			{
				throw new PostSalesReceiptCommandStructureException(ex);
			}
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