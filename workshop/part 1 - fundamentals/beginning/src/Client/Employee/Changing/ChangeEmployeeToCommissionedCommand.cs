namespace AkkaPayroll.Client.Employee.Changing
{
    public class ChangeEmployeeToCommissionedCommand
    {
        public ChangeEmployeeToCommissionedCommand(int id, decimal monthlySalary, decimal commissionRate)
        {
            Id = id;
            MonthlySalary = monthlySalary;
            CommissionRate = commissionRate;
        }

        public int Id { get; }
        public decimal MonthlySalary { get; }
        public decimal CommissionRate { get; }
        
        public override bool Equals(object obj)
        {
            var changeEmployeeToCommissionedCommand = obj as ChangeEmployeeToCommissionedCommand;

            if (ReferenceEquals(changeEmployeeToCommissionedCommand, null)) return false;

            return Id == changeEmployeeToCommissionedCommand.Id
                   && MonthlySalary == changeEmployeeToCommissionedCommand.MonthlySalary
                   && CommissionRate == changeEmployeeToCommissionedCommand.CommissionRate;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ MonthlySalary.GetHashCode();
                hashCode = (hashCode * 397) ^ CommissionRate.GetHashCode();

                return hashCode;
            }
        }

        public override string ToString() =>
            $"{nameof(ChangeEmployeeToCommissionedCommand)} {{ {nameof(Id)}: {Id}, {nameof(MonthlySalary)}: {MonthlySalary}, {nameof(CommissionRate)}: {CommissionRate} }}";
    }
}