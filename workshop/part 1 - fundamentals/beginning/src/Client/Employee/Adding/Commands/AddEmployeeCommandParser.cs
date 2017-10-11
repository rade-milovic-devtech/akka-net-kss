using AkkaPayroll.Client.Employee.Adding.Arguments;

namespace AkkaPayroll.Client.Employee.Adding.Commands
{
	public static class AddEmployeeCommandParser
	{
		public static AddEmployeeCommand Parse(string command)
		{
			var arguments = AddEmployeeCommandArgumentsParser.Parse(command);

			return BuildFrom(arguments);
		}

		private static AddEmployeeCommand BuildFrom(AddEmployeeCommandArguments arguments)
		{
			switch (arguments.Type)
			{
				case EmployeeType.Hourly:
					return BuildAddHourlyEmployeeCommandFrom(arguments);
				case EmployeeType.Salaried:
					return BuildAddSalariedEmployeeCommandFrom(arguments);
				case EmployeeType.Commissioned:
					return BuildAddCommissionedEmployeeCommandFrom(arguments);
				default:
					throw new AddEmployeeCommandStructureException();
			}
		}

		private static AddHourlyEmployeeCommand BuildAddHourlyEmployeeCommandFrom(AddEmployeeCommandArguments arguments)
		{
			var hourlyEmployeeCommandArguments = arguments as AddHourlyEmployeeCommandArguments;

			return new AddHourlyEmployeeCommand(
				hourlyEmployeeCommandArguments.Id,
				hourlyEmployeeCommandArguments.Name,
				hourlyEmployeeCommandArguments.Address,
				hourlyEmployeeCommandArguments.HourlyRate);
		}

		private static AddSalariedEmployeeCommand BuildAddSalariedEmployeeCommandFrom(AddEmployeeCommandArguments arguments)
		{
			var salariedEmployeeCommandArguments = arguments as AddSalariedEmployeeCommandArguments;

			return new AddSalariedEmployeeCommand(
				salariedEmployeeCommandArguments.Id,
				salariedEmployeeCommandArguments.Name,
				salariedEmployeeCommandArguments.Address,
				salariedEmployeeCommandArguments.MonthlySalary);
		}

		private static AddCommissionedEmployeeCommand BuildAddCommissionedEmployeeCommandFrom(AddEmployeeCommandArguments arguments)
		{
			var commissionedEmployeeCommandArguments = arguments as AddCommissionedEmployeeCommandArguments;

			return new AddCommissionedEmployeeCommand(
				commissionedEmployeeCommandArguments.Id,
				commissionedEmployeeCommandArguments.Name,
				commissionedEmployeeCommandArguments.Address,
				commissionedEmployeeCommandArguments.MonthlySalary,
				commissionedEmployeeCommandArguments.CommissionRate);
		}
	}
}