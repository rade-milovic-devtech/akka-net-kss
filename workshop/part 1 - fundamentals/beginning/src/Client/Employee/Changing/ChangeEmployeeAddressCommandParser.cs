using System;
using System.Collections.Generic;
using System.Linq;

namespace AkkaPayroll.Client.Employee.Changing
{
	public static class ChangeEmployeeAddressCommandParser
	{
		private const string Address = "address";
		
		public static ChangeEmployeeAddressCommand Parse(string command)
		{
			try
			{
				var arguments = GetArgumentsFor(command);

				Validate(arguments);
				
				return new ChangeEmployeeAddressCommand(GetIdFrom(arguments), GetAddressFrom(arguments));
			}
			catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
			{
				throw new ChangeEmployeeAddressCommandStructureException(ex);
			}
		}

		private static string[] GetArgumentsFor(string command)
		{
			var commandTokens = command.Split(new[] {'"'}, StringSplitOptions.RemoveEmptyEntries)
				.Where(token => !string.IsNullOrWhiteSpace(token))
				.ToArray();

			var arguments = new List<string>();
			arguments.AddRange(commandTokens[0].Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Skip(1));
			arguments.Add(commandTokens[1]);
			arguments.AddRange(commandTokens.Skip(2));

			return arguments.ToArray();
		}

		private static void Validate(string[] arguments)
		{
			if (arguments.Length > 3)
				throw new ChangeEmployeeAddressCommandStructureException();

			var changeType = GetChangeTypeFrom(arguments);
			if (!string.Equals(changeType, Address, StringComparison.InvariantCultureIgnoreCase))
				throw new ChangeEmployeeAddressCommandStructureException();
		}
		
		private static string GetChangeTypeFrom(string[] arguments) => arguments[1];
		
		private static int GetIdFrom(string[] arguments) => int.Parse(arguments[0]);

		private static string GetAddressFrom(string[] arguments) => arguments[2];
	}
}