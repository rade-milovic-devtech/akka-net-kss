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

				if (!AreValid(arguments))
					throw new PostTimeCardCommandStructureException();

				return new PostTimeCardCommand(
					GetEmployeeIdFrom(arguments),
					GetDateFrom(arguments),
					GetHoursFrom(arguments));
			}
			catch (PostTimeCardCommandStructureException) { throw; }
			catch (Exception ex)
			{
				throw new PostTimeCardCommandStructureException(ex);
			}
		}

		private static bool AreValid(string[] arguments) => arguments.Length == 3;

		private static int GetEmployeeIdFrom(string[] arguments) => int.Parse(arguments[0]);

		private static DateTime GetDateFrom(string[] arguments) => DateParser.Parse(arguments[1]);

		private static int GetHoursFrom(string[] arguments) => int.Parse(arguments[2]);
	}
}