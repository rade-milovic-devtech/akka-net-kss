namespace AkkaPayroll.Client.Commands.Employee
{
	public class AddCommissionedEmployeeCommand : AddEmployeeCommand
	{
		public AddCommissionedEmployeeCommand(int id, string name, string address, decimal monthlySalary, decimal commissionRate)
			: base(id, name, address)
		{
			MonthlySalary = monthlySalary;
			CommissionRate = commissionRate;
		}

		public decimal MonthlySalary { get; }
		public decimal CommissionRate { get; }

		public override bool Equals(object obj)
		{
			var addCommissionedEmployeeCommand = obj as AddCommissionedEmployeeCommand;

			if (ReferenceEquals(addCommissionedEmployeeCommand, null))
				return false;

			return base.Equals(addCommissionedEmployeeCommand)
				&& MonthlySalary == addCommissionedEmployeeCommand.MonthlySalary
				&& CommissionRate == addCommissionedEmployeeCommand.CommissionRate;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = base.GetHashCode();
				hashCode = (hashCode * 397) ^ MonthlySalary.GetHashCode();
				hashCode = (hashCode * 397) ^ CommissionRate.GetHashCode();

				return hashCode;
			}
		}

		public override string ToString() =>
			$"{nameof(AddCommissionedEmployeeCommand)} {{ {nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Address)}: {Address}, {nameof(MonthlySalary)}: {MonthlySalary}, {nameof(CommissionRate)}: {CommissionRate} }}";
	}
}