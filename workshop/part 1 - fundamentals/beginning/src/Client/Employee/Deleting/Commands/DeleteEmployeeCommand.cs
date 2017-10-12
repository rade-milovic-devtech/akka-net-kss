namespace AkkaPayroll.Client.Employee.Deleting.Commands
{
	public class DeleteEmployeeCommand
	{
		public DeleteEmployeeCommand(int id)
		{
			Id = id;
		}

		public int Id { get; }

		public override bool Equals(object obj)
		{
			var deleteEmployeeCommand = obj as DeleteEmployeeCommand;

			if (ReferenceEquals(deleteEmployeeCommand, null))
				return false;

			return Id == deleteEmployeeCommand.Id;
		}

		public override int GetHashCode() => Id.GetHashCode();

		public override string ToString() => $"{nameof(DeleteEmployeeCommand)} {{ {nameof(Id)}: {Id} }}";
	}
}