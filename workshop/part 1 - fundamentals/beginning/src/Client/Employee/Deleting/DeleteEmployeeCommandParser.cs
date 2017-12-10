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

				if (!AreValid(arguments))
					throw new DeleteEmployeeCommandStructureException();

				return new DeleteEmployeeCommand(GetIdFrom(arguments));
			}
			catch (DeleteEmployeeCommandStructureException) { throw; }
			catch (Exception ex)
			{
				throw new DeleteEmployeeCommandStructureException(ex);
			}
		}

		private static bool AreValid(string[] arguments) => arguments.Length == 1;

		private static int GetIdFrom(string[] arguments) => int.Parse(arguments[0]);
	}
}