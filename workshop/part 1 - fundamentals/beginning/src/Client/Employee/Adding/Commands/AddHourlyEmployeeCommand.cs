namespace AkkaPayroll.Client.Employee.Adding.Commands
{
	public class AddHourlyEmployeeCommand : AddEmployeeCommand
	{
		public AddHourlyEmployeeCommand(int id, string name, string address, decimal hourlyRate)
			: base(id, name, address)
		{
			HourlyRate = hourlyRate;
		}

		public decimal HourlyRate { get; }

		public override bool Equals(object obj)
		{
			var addHourlyEmployeeCommand = obj as AddHourlyEmployeeCommand;

			if (ReferenceEquals(addHourlyEmployeeCommand, null)) return false;

			return base.Equals(addHourlyEmployeeCommand)
				&& HourlyRate == addHourlyEmployeeCommand.HourlyRate;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = base.GetHashCode();
				hashCode = (hashCode * 397) ^ HourlyRate.GetHashCode();

				return hashCode;
			}
		}

		public override string ToString() =>
			$"{nameof(AddHourlyEmployeeCommand)} {{ {nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Address)}: {Address}, {nameof(HourlyRate)}: {HourlyRate} }}";
	}
}