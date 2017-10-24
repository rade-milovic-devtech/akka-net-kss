using System;
using System.Linq;
using AkkaPayroll.Client.Common;

namespace AkkaPayroll.Client.TimeCard.Adding.Commands
{
	public static class AddTimeCardCommandParser
	{
		public static AddTimeCardCommand Parse(string command)
		{
			var arguments = GetArgumentsFor(command);

			Validate(arguments);

			try
			{
				var employeeId = GetEmployeeIdFor(arguments);
				var date = GetDateFor(arguments);
				var hours = GetHoursFor(arguments);

				return new AddTimeCardCommand(employeeId, date, hours);
			}
			catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
			{
				throw new AddTimeCardCommandStructureException(ex);
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
				throw new AddTimeCardCommandStructureException();
		}

		private static int GetEmployeeIdFor(string[] arguments) => int.Parse(arguments[0]);

		private static DateTime GetDateFor(string[] arguments) => DateParser.Parse(arguments[1]);

		private static int GetHoursFor(string[] arguments) => int.Parse(arguments[2]);
	}
}