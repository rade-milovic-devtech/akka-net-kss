using System;

namespace AkkaPayroll.Client.Employee.Adding.Arguments
{
	internal class AddHourlyEmployeeCommandArguments : AddEmployeeCommandArguments
	{
		public AddHourlyEmployeeCommandArguments(string[] arguments) : base(EmployeeType.Hourly, arguments)
		{
			HourlyRate = GetHourlyRateFrom(arguments);
		}

		public decimal HourlyRate { get; }

		private decimal GetHourlyRateFrom(string[] arguments)
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
	}
}