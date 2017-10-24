namespace AkkaPayroll.Client.Employee.Adding
{
	public abstract class AddEmployeeCommand
	{
		protected AddEmployeeCommand(int id, string name, string address)
		{
			Id = id;
			Name = name;
			Address = address;
		}

		public int Id { get; }
		public string Name { get; }
		public string Address { get; }

		public override bool Equals(object obj)
		{
			var addEmployeeCommand = obj as AddEmployeeCommand;

			if (ReferenceEquals(addEmployeeCommand, null))
				return false;

			return Id == addEmployeeCommand.Id
				&& Name == addEmployeeCommand.Name
				&& Address == addEmployeeCommand.Address;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Id.GetHashCode();
				hashCode = (hashCode * 397) ^ Name.GetHashCode();
				hashCode = (hashCode * 397) ^ Address.GetHashCode();

				return hashCode;
			}
		}
	}
}