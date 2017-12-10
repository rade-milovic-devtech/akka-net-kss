using System;
using AkkaPayroll.Client.Common;

namespace AkkaPayroll.Client.Employee.Adding
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
				var arguments = CommandsArgumentsExtractor.ExtractFrom(command);

				var employeeType = GetEmployeeTypeFrom(arguments);

				Validate(arguments, employeeType);

				return BuildFrom(arguments, employeeType);
			}
			catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
			{
				throw new AddEmployeeCommandStructureException(ex);
			}
		}

		private static EmployeeType GetEmployeeTypeFrom(string[] arguments)
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
				GetIdFrom(arguments),
				GetNameFrom(arguments),
				GetAddressFrom(arguments),
				GetHourlyRateFrom(arguments));

		private static AddSalariedEmployeeCommand BuildAddSalariedEmployeeCommandFrom(string[] arguments) =>
			new AddSalariedEmployeeCommand(
				GetIdFrom(arguments),
				GetNameFrom(arguments),
				GetAddressFrom(arguments),
				GetMonthlySalaryFrom(arguments));

		private static AddCommissionedEmployeeCommand BuildAddCommissionedEmployeeCommandFrom(string[] arguments) =>
			new AddCommissionedEmployeeCommand(
				GetIdFrom(arguments),
				GetNameFrom(arguments),
				GetAddressFrom(arguments),
				GetMonthlySalaryFrom(arguments),
				GetCommissionRateFrom(arguments));

		private static int GetIdFrom(string[] arguments) => int.Parse(arguments[0]);

		private static string GetNameFrom(string[] arguments) => arguments[1];

		private static string GetAddressFrom(string[] arguments) => arguments[2];

		private static decimal GetHourlyRateFrom(string[] arguments) => decimal.Parse(arguments[4]);

		private static decimal GetMonthlySalaryFrom(string[] arguments) => decimal.Parse(arguments[4]);

		private static decimal GetCommissionRateFrom(string[] arguments) => decimal.Parse(arguments[5]);
	}
}