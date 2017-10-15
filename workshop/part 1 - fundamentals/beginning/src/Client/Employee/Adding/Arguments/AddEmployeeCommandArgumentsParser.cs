using System;
using System.Collections.Generic;
using System.Linq;

namespace AkkaPayroll.Client.Employee.Adding.Arguments
{
	internal static class AddEmployeeCommandArgumentsParser
	{
		private const string HourlyEmployee = "H";
		private const string SalariedEmployee = "S";
		private const string CommissionedEmployee = "C";

		public static AddEmployeeCommandArguments Parse(string command)
		{
			var arguments = GetArgumentsFor(command);

			return BuildFrom(arguments);
		}

		private static string[] GetArgumentsFor(string command)
		{
			try
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
			catch (IndexOutOfRangeException ex)
			{
				throw new AddEmployeeCommandStructureException(ex);
			}
		}

		private static AddEmployeeCommandArguments BuildFrom(string[] arguments)
		{
			try
			{
				var employeeTypeArgument = arguments[3];

				if (string.Equals(employeeTypeArgument, HourlyEmployee, StringComparison.InvariantCultureIgnoreCase))
					return AddHourlyEmployeeCommandArguments.CreateFrom(arguments);
				if (string.Equals(employeeTypeArgument, SalariedEmployee, StringComparison.InvariantCultureIgnoreCase))
					return AddSalariedEmployeeCommandArguments.CreateFrom(arguments);
				if (string.Equals(employeeTypeArgument, CommissionedEmployee, StringComparison.InvariantCultureIgnoreCase))
					return AddCommissionedEmployeeCommandArguments.CreateFrom(arguments);

				throw new AddEmployeeCommandStructureException();
			}
			catch (IndexOutOfRangeException ex)
			{
				throw new AddEmployeeCommandStructureException(ex);
			}
		}
	}
}