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

				if (!AreValid(arguments))
					throw new ChangeEmployeeNameCommandStructureException();

				return new ChangeEmployeeNameCommand(GetIdFrom(arguments), GetNameFrom(arguments));
			}
			catch (ChangeEmployeeNameCommandStructureException) { throw; }
			catch (Exception ex)
			{
				throw new ChangeEmployeeNameCommandStructureException(ex);
			}
		}

		private static bool AreValid(string[] arguments) =>
			arguments.Length == 3 &&
			ChangeTypeIsName(arguments);

		private static bool ChangeTypeIsName(string[] arguments) =>
			string.Equals(GetChangeTypeFrom(arguments), Name, StringComparison.InvariantCultureIgnoreCase);

		private static string GetChangeTypeFrom(string[] arguments) => arguments[1];

		private static int GetIdFrom(string[] arguments) => int.Parse(arguments[0]);

		private static string GetNameFrom(string[] arguments) => arguments[2];
	}
}