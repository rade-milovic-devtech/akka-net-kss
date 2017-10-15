using System;

namespace AkkaPayroll.Client.Employee.Adding.Arguments
{
	internal class AddHourlyEmployeeCommandArguments : AddEmployeeCommandArguments
	{
		public static AddHourlyEmployeeCommandArguments CreateFrom(string[] arguments)
		{
			Validate(arguments);

			return new AddHourlyEmployeeCommandArguments(
				GetIdFrom(arguments),
				GetNameFrom(arguments),
				GetAddressFrom(arguments),
				GetHourlyRateFrom(arguments));
		}

		private static void Validate(string[] arguments)
		{
			if (arguments.Length > 5)
				throw new AddEmployeeCommandStructureException();
		}

		private static decimal GetHourlyRateFrom(string[] arguments)
		{
			try
			{
				return decimal.Parse(arguments[4]);
			}
			catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
			{
				throw new AddEmployeeCommandStructureException(ex);
			}
		}

		private AddHourlyEmployeeCommandArguments(int id, string name, string address, decimal hourlyRate)
			: base(id, name, address, EmployeeType.Hourly)
		{
			HourlyRate = hourlyRate;
		}

		public decimal HourlyRate { get; }
	}
}