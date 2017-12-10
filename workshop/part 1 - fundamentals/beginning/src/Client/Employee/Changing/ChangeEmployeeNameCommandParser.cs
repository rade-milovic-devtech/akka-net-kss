using System;
using AkkaPayroll.Client.Common;

namespace AkkaPayroll.Client.Employee.Changing
{
	public static class ChangeEmployeeNameCommandParser
	{
		private const string Name = "name";

		public static ChangeEmployeeNameCommand Parse(string command)
		{
			try
			{
				var arguments = CommandsArgumentsExtractor.ExtractFrom(command);

				Validate(arguments);

				return new ChangeEmployeeNameCommand(GetIdFrom(arguments), GetNameFrom(arguments));
			}
			catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
			{
				throw new ChangeEmployeeNameCommandStructureException(ex);
			}
		}

		private static void Validate(string[] arguments)
		{
			if (arguments.Length > 3)
				throw new ChangeEmployeeNameCommandStructureException();

			var changeType = GetChangeTypeFrom(arguments);
			if (!string.Equals(changeType, Name, StringComparison.InvariantCultureIgnoreCase))
				throw new ChangeEmployeeNameCommandStructureException();
		}

		private static string GetChangeTypeFrom(string[] arguments) => arguments[1];

		private static int GetIdFrom(string[] arguments) => int.Parse(arguments[0]);

		private static string GetNameFrom(string[] arguments) => arguments[2];
	}
}