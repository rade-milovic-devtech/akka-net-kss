namespace AkkaPayroll.Client.Employee.Changing
{
    public class ChangeEmployeeToHourlyCommand
    {
        public ChangeEmployeeToHourlyCommand(int id, decimal hourlyRate)
        {
            Id = id;
            HourlyRate = hourlyRate;
        }

        public int Id { get; }
        public decimal HourlyRate { get; }
        
        public override bool Equals(object obj)
        {
            var changeEmployeeToHourlyCommand = obj as ChangeEmployeeToHourlyCommand;

            if (ReferenceEquals(changeEmployeeToHourlyCommand, null)) return false;

            return Id == changeEmployeeToHourlyCommand.Id
                   && HourlyRate == changeEmployeeToHourlyCommand.HourlyRate;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ HourlyRate.GetHashCode();

                return hashCode;
            }
        }

        public override string ToString() =>
            $"{nameof(ChangeEmployeeToHourlyCommand)} {{ {nameof(Id)}: {Id}, {nameof(HourlyRate)}: {HourlyRate} }}";
    }
}