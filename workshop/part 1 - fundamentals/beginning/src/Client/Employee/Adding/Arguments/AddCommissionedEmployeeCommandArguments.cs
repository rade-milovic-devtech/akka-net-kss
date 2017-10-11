using System;

namespace AkkaPayroll.Client.Employee.Adding.Arguments
{
	internal class AddCommissionedEmployeeCommandArguments : AddEmployeeCommandArguments
	{
		public AddCommissionedEmployeeCommandArguments(string[] arguments) : base(EmployeeType.Commissioned, arguments)
		{
			MonthlySalary = GetMonthlySalaryFrom(arguments);
			CommissionRate = GetCommissionedRateFrom(arguments);
		}

		public decimal MonthlySalary { get; }

		public decimal CommissionRate { get; }

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

		private decimal GetCommissionedRateFrom(string[] arguments)
		{
			try
			{
				return decimal.Parse(arguments[5]);
			}
			catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
			{
				throw new AddEmployeeCommandStructureException(ex);
			}
		}
	}
}