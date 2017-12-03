namespace AkkaPayroll.Client.Employee.Changing
{
    public class ChangeEmployeeToSalariedCommand
    {
        public ChangeEmployeeToSalariedCommand(int id, decimal monthlySalary)
        {
            Id = id;
            MonthlySalary = monthlySalary;
        }

        public int Id { get; }
        public decimal MonthlySalary { get; }
        
        public override bool Equals(object obj)
        {
            var changeEmployeeToSalariedCommand = obj as ChangeEmployeeToSalariedCommand;

            if (ReferenceEquals(changeEmployeeToSalariedCommand, null)) return false;

            return Id == changeEmployeeToSalariedCommand.Id
                   && MonthlySalary == changeEmployeeToSalariedCommand.MonthlySalary;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ MonthlySalary.GetHashCode();

                return hashCode;
            }
        }

        public override string ToString() =>
            $"{nameof(ChangeEmployeeToSalariedCommand)} {{ {nameof(Id)}: {Id}, {nameof(MonthlySalary)}: {MonthlySalary} }}";
    }
}