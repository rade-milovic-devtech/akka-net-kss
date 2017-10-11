using System;

namespace AkkaPayroll.Client.Employee.Adding.Arguments
{
	internal class AddSalariedEmployeeCommandArguments : AddEmployeeCommandArguments
	{
		public AddSalariedEmployeeCommandArguments(string[] arguments) : base(EmployeeType.Salaried, arguments)
		{
			MonthlySalary = GetMonthlySalaryFrom(arguments);
		}

		public decimal MonthlySalary { get; }

		private decimal GetMonthlySalaryFrom(string[] arguments)
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