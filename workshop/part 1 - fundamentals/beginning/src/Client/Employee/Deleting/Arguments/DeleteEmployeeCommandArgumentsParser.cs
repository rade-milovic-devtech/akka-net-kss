using System;
using System.Collections.Generic;
using System.Linq;

namespace AkkaPayroll.Client.Employee.Deleting.Arguments
{
	internal static class DeleteEmployeeCommandArgumentsParser
	{
		public static DeleteEmployeeArguments Parse(string command)
		{
			var arguments = GetArgumentsFor(command);

			return DeleteEmployeeArguments.CreateFrom(arguments);
		}

		private static string[] GetArgumentsFor(string command)
		{
			var commandTokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
				.Where(token => !string.IsNullOrWhiteSpace(token))
				.ToArray();

			return new List<string>(commandTokens.Skip(1)).ToArray();
		}
	}
}