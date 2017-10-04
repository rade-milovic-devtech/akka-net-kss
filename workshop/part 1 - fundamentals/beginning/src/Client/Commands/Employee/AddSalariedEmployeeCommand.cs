namespace AkkaPayroll.Client.Commands.Employee
{
	public class AddSalariedEmployeeCommand : AddEmployeeCommand
	{
		public AddSalariedEmployeeCommand(int id, string name, string address, decimal monthlySalary)
			: base(id, name, address)
		{
			MonthlySalary = monthlySalary;
		}

		public decimal MonthlySalary { get; }

		public override bool Equals(object obj)
		{
			var addSalariedEmployeeCommand = obj as AddSalariedEmployeeCommand;

			if (ReferenceEquals(addSalariedEmployeeCommand, null))
				return false;

			return base.Equals(addSalariedEmployeeCommand)
				&& MonthlySalary == addSalariedEmployeeCommand.MonthlySalary;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = base.GetHashCode();
				hashCode = (hashCode * 397) ^ MonthlySalary.GetHashCode();

				return hashCode;
			}
		}

		public override string ToString() =>
			$"{nameof(AddHourlyEmployeeCommand)} {{ {nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Address)}: {Address}, {nameof(MonthlySalary)}: {MonthlySalary} }}";
	}
}