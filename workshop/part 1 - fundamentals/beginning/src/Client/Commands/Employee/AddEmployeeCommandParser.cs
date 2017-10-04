using System;
using System.Collections.Generic;
using System.Linq;

namespace AkkaPayroll.Client.Commands.Employee
{
	public static class AddEmployeeCommandParser
	{
		private const string HourlyEmployee = "H";
		private const string SalariedEmployee = "S";

		public static AddEmployeeCommand Parse(string command)
		{
			var arguments = GetArgumentsFor(command);

			return BuildCommandFrom(arguments);
		}

		private static List<string> GetArgumentsFor(string command)
		{
			var tokens = command.Split(new[] { '"' }, StringSplitOptions.RemoveEmptyEntries)
				.Where(token => !string.IsNullOrWhiteSpace(token))
				.ToArray();

			var arguments = new List<string>();
			arguments.Add(tokens[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
			arguments.Add(tokens[1]);
			arguments.Add(tokens[2]);
			arguments.AddRange(tokens[3].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

			return arguments;
		}

		private static AddEmployeeCommand BuildCommandFrom(List<string> arguments)
		{
			var employeeType = GetEmployeeTypeFrom(arguments);
			var id = GetIdFrom(arguments);
			var name = GetNameFrom(arguments);
			var address = GetAddressFrom(arguments);

			if (string.Equals(employeeType, HourlyEmployee, StringComparison.InvariantCultureIgnoreCase))
				return new AddHourlyEmployeeCommand(id, name, address, GetHourlyRateFrom(arguments));
			if (string.Equals(employeeType, SalariedEmployee, StringComparison.InvariantCultureIgnoreCase))
				return new AddSalariedEmployeeCommand(id, name, address, GetMonthlySalaryFrom(arguments));

			return new AddCommissionedEmployeeCommand(id, name, address, GetMonthlySalaryFrom(arguments), GetCommissionRateFrom(arguments));
		}

		private static string GetEmployeeTypeFrom(List<string> arguments) => arguments[3];

		private static int GetIdFrom(List<string> arguments) => int.Parse(arguments[0]);

		private static string GetNameFrom(List<string> arguments) => arguments[1];

		private static string GetAddressFrom(List<string> arguments) => arguments[2];

		private static decimal GetHourlyRateFrom(List<string> arguments) => decimal.Parse(arguments[4]);

		private static decimal GetMonthlySalaryFrom(List<string> arguments) => decimal.Parse(arguments[4]);

		private static decimal GetCommissionRateFrom(List<string> arguments) => decimal.Parse(arguments[5]);
	}
}