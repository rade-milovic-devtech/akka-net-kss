using System;
using AkkaPayroll.Client.Common;

namespace AkkaPayroll.Client.Employee.Changing
{
	public static class ChangeEmployeeAddressCommandParser
	{
		private const string Address = "address";
		
		public static ChangeEmployeeAddressCommand Parse(string command)
		{
			try
			{
				var arguments = CommandsArgumentsExtractor.ExtractFrom(command);

				if (!AreValid(arguments))
					throw new ChangeEmployeeAddressCommandStructureException();
				
				return new ChangeEmployeeAddressCommand(GetIdFrom(arguments), GetAddressFrom(arguments));
			}
			catch (ChangeEmployeeAddressCommandStructureException) { throw; }
			catch (Exception ex)
			{
				throw new ChangeEmployeeAddressCommandStructureException(ex);
			}
		}

		private static bool AreValid(string[] arguments) =>
			arguments.Length == 3 &&
			ChangeTypeIsAddress(arguments);

		private static bool ChangeTypeIsAddress(string[] arguments) =>
			string.Equals(GetChangeTypeFrom(arguments), Address, StringComparison.InvariantCultureIgnoreCase);

		private static string GetChangeTypeFrom(string[] arguments) => arguments[1];
		
		private static int GetIdFrom(string[] arguments) => int.Parse(arguments[0]);

		private static string GetAddressFrom(string[] arguments) => arguments[2];
	}
}