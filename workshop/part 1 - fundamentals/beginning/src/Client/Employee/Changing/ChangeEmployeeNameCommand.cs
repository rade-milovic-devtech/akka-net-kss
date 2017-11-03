namespace AkkaPayroll.Client.Employee.Changing
{
	public class ChangeEmployeeNameCommand
	{
		public int Id { get; }
		public string Name { get; }

		public ChangeEmployeeNameCommand(int id, string name)
		{
			Id = id;
			Name = name;
		}

		public override bool Equals(object obj)
		{
			var changeEmployeeNameCommand = obj as ChangeEmployeeNameCommand;

			if (ReferenceEquals(changeEmployeeNameCommand, null))
				return false;

			return Id == changeEmployeeNameCommand.Id && Name == changeEmployeeNameCommand.Name;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Id.GetHashCode();
				hashCode = (hashCode * 397) ^ Name.GetHashCode();

				return hashCode;
			}
		}

		public override string ToString() =>
			$"{nameof(ChangeEmployeeNameCommand)} {{ {nameof(Id)}: {Id}, {nameof(Name)}: {Name} }}";
	}
}