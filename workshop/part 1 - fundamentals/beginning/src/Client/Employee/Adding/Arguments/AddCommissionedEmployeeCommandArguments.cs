using System;

namespace AkkaPayroll.Client.Employee.Adding.Arguments
{
	internal class AddCommissionedEmployeeCommandArguments : AddEmployeeCommandArguments
	{
		public static AddCommissionedEmployeeCommandArguments CreateFrom(string[] arguments)
		{
			Validate(arguments);

			return new AddCommissionedEmployeeCommandArguments(
				GetIdFrom(arguments),
				GetNameFrom(arguments),
				GetAddressFrom(arguments),
				GetMonthlySalaryFrom(arguments),
				GetCommissionedRateFrom(arguments));
		}

		private static void Validate(string[] arguments)
		{
			if (arguments.Length > 6)
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

		private static decimal GetCommissionedRateFrom(string[] arguments)
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

		private AddCommissionedEmployeeCommandArguments(int id, string name, string address, decimal monthlySalary, decimal commissionRate)
			: base(id, name, address, EmployeeType.Commissioned)
		{
			MonthlySalary = monthlySalary;
			CommissionRate = commissionRate;
		}

		public decimal MonthlySalary { get; }

		public decimal CommissionRate { get; }
	}
}