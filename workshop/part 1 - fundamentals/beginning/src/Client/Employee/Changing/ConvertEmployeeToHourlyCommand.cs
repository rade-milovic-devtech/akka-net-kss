namespace AkkaPayroll.Client.Employee.Changing
{
    public class ConvertEmployeeToHourlyCommand
    {
        public ConvertEmployeeToHourlyCommand(int id, decimal hourlyRate)
        {
            Id = id;
            HourlyRate = hourlyRate;
        }

        public int Id { get; }
        public decimal HourlyRate { get; }
        
        public override bool Equals(object obj)
        {
            var convertEmployeeToHourlyCommand = obj as ConvertEmployeeToHourlyCommand;

            if (ReferenceEquals(convertEmployeeToHourlyCommand, null)) return false;

            return Id == convertEmployeeToHourlyCommand.Id
                   && HourlyRate == convertEmployeeToHourlyCommand.HourlyRate;
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
            $"{nameof(ConvertEmployeeToHourlyCommand)} {{ {nameof(Id)}: {Id}, {nameof(HourlyRate)}: {HourlyRate} }}";
    }
}