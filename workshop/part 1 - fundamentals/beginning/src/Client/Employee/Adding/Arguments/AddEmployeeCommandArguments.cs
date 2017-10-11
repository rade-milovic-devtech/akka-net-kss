using System;

namespace AkkaPayroll.Client.Employee.Adding.Arguments
{
	internal abstract class AddEmployeeCommandArguments
	{
		protected AddEmployeeCommandArguments(EmployeeType type, string[] arguments)
		{
			Id = GetIdFrom(arguments);
			Name = GetNameFrom(arguments);
			Address = GetAddressFrom(arguments);
			Type = type;
		}

		public int Id { get; }
		public string Name { get; }
		public string Address { get; }
		public EmployeeType Type { get; }

		private int GetIdFrom(string[] arguments)
		{
			try
			{
				return int.Parse(arguments[0]);
			}
			catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
			{
				throw new AddEmployeeCommandStructureException(ex);
			}
		}

		private string GetNameFrom(string[] arguments)
		{
			try
			{
				return arguments[1];
			}
			catch (IndexOutOfRangeException ex)
			{
				throw new AddEmployeeCommandStructureException(ex);
			}
		}

		private string GetAddressFrom(string[] arguments)
		{
			try
			{
				return arguments[2];
			}
			catch (IndexOutOfRangeException ex)
			{
				throw new AddEmployeeCommandStructureException(ex);
			}
		}
	}
}