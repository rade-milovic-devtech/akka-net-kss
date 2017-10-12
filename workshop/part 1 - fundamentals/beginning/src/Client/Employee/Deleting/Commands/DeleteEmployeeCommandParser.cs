using System;

namespace AkkaPayroll.Client.Employee.Deleting.Commands
{
	public static class DeleteEmployeeCommandParser
	{
		public static DeleteEmployeeCommand Parse(string command) =>
			new DeleteEmployeeCommand(GetIdFrom(command));

		public static int GetIdFrom(string command)
		{
			var commandTokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

			return int.Parse(commandTokens[1]);
		}
	}
}