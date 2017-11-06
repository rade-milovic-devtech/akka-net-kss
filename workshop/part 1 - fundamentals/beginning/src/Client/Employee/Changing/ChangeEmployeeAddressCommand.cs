using System;

namespace AkkaPayroll.Client.Employee.Changing
{
	public class ChangeEmployeeAddressCommand
	{
		public ChangeEmployeeAddressCommand(int id, string address)
		{
			Id = id;
			Address = address;
		}

		public int Id { get; }
		public string Address { get; }

		public override bool Equals(object obj)
		{
			var changeEmployeeAddressCommand = obj as ChangeEmployeeAddressCommand;

			if (ReferenceEquals(changeEmployeeAddressCommand, null))
				return false;

			return Id == changeEmployeeAddressCommand.Id &&
				string.Equals(Address, changeEmployeeAddressCommand.Address, StringComparison.CurrentCultureIgnoreCase);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Id.GetHashCode();
				hashCode = (hashCode * 397) ^ Address.GetHashCode();

				return hashCode;
			}
		}

		public override string ToString() =>
			$"{nameof(ChangeEmployeeAddressCommand)} {{ {nameof(Id)}: {Id}, {nameof(Address)}: {Address} }}";
	}
}