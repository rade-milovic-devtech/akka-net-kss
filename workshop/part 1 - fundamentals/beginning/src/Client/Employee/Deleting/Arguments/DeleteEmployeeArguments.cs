using System;

namespace AkkaPayroll.Client.Employee.Deleting.Arguments
{
	internal class DeleteEmployeeArguments
	{
		public static DeleteEmployeeArguments CreateFrom(string[] arguments)
		{
			Validate(arguments);

			return new DeleteEmployeeArguments(GetIdFrom(arguments));
		}

		private static void Validate(string[] arguments)
		{
			if (arguments.Length > 1)
				throw new DeleteEmployeeCommandStructureException();
		}

		private static int GetIdFrom(string[] arguments)
		{
			try
			{	
				return int.Parse(arguments[0]);
			}
			catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
			{
				throw new DeleteEmployeeCommandStructureException(ex);
			}
		}

		private DeleteEmployeeArguments(int id)
		{
			Id = id;
		}

		public int Id { get; }
	}
}