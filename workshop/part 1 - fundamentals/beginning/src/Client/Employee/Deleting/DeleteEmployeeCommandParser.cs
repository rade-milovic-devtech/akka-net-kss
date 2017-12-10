using System;
using AkkaPayroll.Client.Common;

namespace AkkaPayroll.Client.Employee.Deleting
{
	public static class DeleteEmployeeCommandParser
	{
		public static DeleteEmployeeCommand Parse(string command)
		{
			try
			{
				var arguments = CommandsArgumentsExtractor.ExtractFrom(command);

				Validate(arguments);

				return new DeleteEmployeeCommand(GetIdFrom(arguments));
			}
			catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
			{
				throw new DeleteEmployeeCommandStructureException(ex);
			}
		}

		private static void Validate(string[] arguments)
		{
			if (arguments.Length > 1)
				throw new DeleteEmployeeCommandStructureException();
		}

		private static int GetIdFrom(string[] arguments) => int.Parse(arguments[0]);
	}
}