using System;
using AkkaPayroll.Client.Common;

namespace AkkaPayroll.Client.TimeCard.Posting
{
	public static class PostTimeCardCommandParser
	{
		public static PostTimeCardCommand Parse(string command)
		{
			try
			{
				var arguments = CommandsArgumentsExtractor.ExtractFrom(command);

				Validate(arguments);

				return new PostTimeCardCommand(
					GetEmployeeIdFrom(arguments),
					GetDateFrom(arguments),
					GetHoursFrom(arguments));
			}
			catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
			{
				throw new PostTimeCardCommandStructureException(ex);
			}
		}

		private static void Validate(string[] arguments)
		{
			if (arguments.Length > 3)
				throw new PostTimeCardCommandStructureException();
		}

		private static int GetEmployeeIdFrom(string[] arguments) => int.Parse(arguments[0]);

		private static DateTime GetDateFrom(string[] arguments) => DateParser.Parse(arguments[1]);

		private static int GetHoursFrom(string[] arguments) => int.Parse(arguments[2]);
	}
}