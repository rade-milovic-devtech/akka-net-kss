using AkkaPayroll.Client.Employee.Deleting.Arguments;

namespace AkkaPayroll.Client.Employee.Deleting.Commands
{
	public static class DeleteEmployeeCommandParser
	{
		public static DeleteEmployeeCommand Parse(string command)
		{
			var arguments = DeleteEmployeeCommandArgumentsParser.Parse(command);

			return new DeleteEmployeeCommand(arguments.Id);
		}
	}
}