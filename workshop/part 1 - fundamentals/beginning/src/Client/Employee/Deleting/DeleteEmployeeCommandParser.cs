using System;
using System.Linq;

namespace AkkaPayroll.Client.Employee.Deleting
{
	public static class DeleteEmployeeCommandParser
	{
		public static DeleteEmployeeCommand Parse(string command)
		{
			var arguments = GetArgumentsFor(command);

			Validate(arguments);

			try
			{
				var id = GetIdFrom(arguments);

				return new DeleteEmployeeCommand(id);
			}
			catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
			{
				throw new DeleteEmployeeCommandStructureException(ex);
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
			if (arguments.Length > 1)
				throw new DeleteEmployeeCommandStructureException();
		}

		private static int GetIdFrom(string[] arguments) => int.Parse(arguments[0]);
	}
}