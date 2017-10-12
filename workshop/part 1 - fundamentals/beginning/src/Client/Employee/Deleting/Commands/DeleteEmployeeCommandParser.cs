using System;

namespace AkkaPayroll.Client.Employee.Deleting.Commands
{
	public static class DeleteEmployeeCommandParser
	{
		public static DeleteEmployeeCommand Parse(string command)
		{
			var commandTokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			var id = int.Parse(commandTokens[1]);

			return new DeleteEmployeeCommand(id);
		}
	}
}