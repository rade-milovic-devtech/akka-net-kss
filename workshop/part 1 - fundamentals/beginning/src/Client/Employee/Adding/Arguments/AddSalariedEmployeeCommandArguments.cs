using System;

namespace AkkaPayroll.Client.Employee.Adding.Arguments
{
	internal class AddSalariedEmployeeCommandArguments : AddEmployeeCommandArguments
	{
		public static AddSalariedEmployeeCommandArguments CreateFrom(string[] arguments)
		{
			Validate(arguments);

			return new AddSalariedEmployeeCommandArguments(
				GetIdFrom(arguments),
				GetNameFrom(arguments),
				GetAddressFrom(arguments),
				GetMonthlySalaryFrom(arguments));
		}

		private static void Validate(string[] arguments)
		{
			if (arguments.Length > 5)
				throw new AddEmployeeCommandStructureException();
		}

		private static decimal GetMonthlySalaryFrom(string[] arguments)
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

		private AddSalariedEmployeeCommandArguments(int id, string name, string address, decimal monthlySalary)
			: base(id, name, address, EmployeeType.Salaried)
		{
			MonthlySalary = monthlySalary;
		}

		public decimal MonthlySalary { get; }
	}
}