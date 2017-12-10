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

				if (!AreValid(arguments))
					throw new PostSalesReceiptCommandStructureException();

				return new PostSalesReceiptCommand(
					GetEmployeeIdFrom(arguments),
					GetDateFrom(arguments),
					GetAmountFrom(arguments));
			}
			catch (PostSalesReceiptCommandStructureException) { throw; }
			catch (Exception ex)
			{
				throw new PostSalesReceiptCommandStructureException(ex);
			}
		}

		private static bool AreValid(string[] arguments) => arguments.Length == 3;

		private static int GetEmployeeIdFrom(string[] arguments) => int.Parse(arguments[0]);

		private static DateTime GetDateFrom(string[] arguments) => DateParser.Parse(arguments[1]);

		private static decimal GetAmountFrom(string[] arguments) => decimal.Parse(arguments[2]);
	}
}