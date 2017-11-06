using System;
using System.Collections.Generic;
using System.Linq;

namespace AkkaPayroll.Client.Employee.Changing
{
	public static class ChangeEmployeeAddressCommandParser
	{
		public static ChangeEmployeeAddressCommand Parse(string command)
		{
			var arguments = GetArgumentsFor(command);

			return new ChangeEmployeeAddressCommand(GetIdFrom(arguments), GetAddressFrom(arguments));
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

		private static int GetIdFrom(string[] arguments) => int.Parse(arguments[0]);

		private static string GetAddressFrom(string[] arguments) => arguments[2];
	}
}