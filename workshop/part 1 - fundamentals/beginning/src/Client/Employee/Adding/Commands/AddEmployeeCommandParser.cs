using System;
using System.Collections.Generic;
using System.Linq;

namespace AkkaPayroll.Client.Employee.Adding.Commands
{
	public static class AddEmployeeCommandParser
	{
		private const string HourlyEmployee = "H";
		private const string SalariedEmployee = "S";
		private const string CommissionedEmployee = "C";

		public static AddEmployeeCommand Parse(string command)
		{
			try
			{
				var arguments = GetArgumentsFor(command);

				var employeeType = GetEmployeeTypeFor(arguments);

				Validate(arguments, employeeType);

				return BuildFrom(arguments, employeeType);
			}
			catch (AddEmployeeCommandStructureException ex)
			{
				throw;
			}
			catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
			{
				throw new AddEmployeeCommandStructureException(ex);
			}
		}

		private static string[] GetArgumentsFor(string command)
		{
			var commandTokens = command.Split(new[] { '"' }, StringSplitOptions.RemoveEmptyEntries)
				.Where(token => !string.IsNullOrWhiteSpace(token))
				.ToArray();

			var arguments = new List<string>();
			arguments.Add(commandTokens[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
			arguments.Add(commandTokens[1]);
			arguments.Add(commandTokens[2]);
			arguments.AddRange(commandTokens[3].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

			return arguments.ToArray();
		}

		private static EmployeeType GetEmployeeTypeFor(string[] arguments)
		{
			var employeeTypeArgument = arguments[3];

			if (string.Equals(employeeTypeArgument, HourlyEmployee, StringComparison.InvariantCultureIgnoreCase))
				return EmployeeType.Hourly;
			if (string.Equals(employeeTypeArgument, SalariedEmployee, StringComparison.InvariantCultureIgnoreCase))
				return EmployeeType.Salaried;
			if (string.Equals(employeeTypeArgument, CommissionedEmployee, StringComparison.InvariantCultureIgnoreCase))
				return EmployeeType.Commissioned;

			throw new AddEmployeeCommandStructureException();
		}

		private static void Validate(string[] arguments, EmployeeType employeeType)
		{
			if (employeeType == EmployeeType.Commissioned && arguments.Length <= 6) return;

			if (arguments.Length <= 5) return;

			throw new AddEmployeeCommandStructureException();
		}

		private static AddEmployeeCommand BuildFrom(string[] arguments, EmployeeType employeeType)
		{
			switch (employeeType)
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

		private static AddHourlyEmployeeCommand BuildAddHourlyEmployeeCommandFrom(string[] arguments) =>
			new AddHourlyEmployeeCommand(
				GetIdFor(arguments),
				GetNameFor(arguments),
				GetAddressFor(arguments),
				GetHourlyRateFor(arguments));

		private static AddSalariedEmployeeCommand BuildAddSalariedEmployeeCommandFrom(string[] arguments) =>
			new AddSalariedEmployeeCommand(
				GetIdFor(arguments),
				GetNameFor(arguments),
				GetAddressFor(arguments),
				GetMonthlySalaryFor(arguments));

		private static AddCommissionedEmployeeCommand BuildAddCommissionedEmployeeCommandFrom(string[] arguments) =>
			new AddCommissionedEmployeeCommand(
				GetIdFor(arguments),
				GetNameFor(arguments),
				GetAddressFor(arguments),
				GetMonthlySalaryFor(arguments),
				GetCommissionRateFor(arguments));

		private static int GetIdFor(string[] arguments) => int.Parse(arguments[0]);

		private static string GetNameFor(string[] arguments) => arguments[1];

		private static string GetAddressFor(string[] arguments) => arguments[2];

		private static decimal GetHourlyRateFor(string[] arguments) => decimal.Parse(arguments[4]);

		private static decimal GetMonthlySalaryFor(string[] arguments) => decimal.Parse(arguments[4]);

		private static decimal GetCommissionRateFor(string[] arguments) => decimal.Parse(arguments[5]);
	}
}