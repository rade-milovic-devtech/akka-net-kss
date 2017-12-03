namespace AkkaPayroll.Client.Employee.Changing
{
    public class ChangeEmployeePaymentTypeToHoldCommand
    {
        public ChangeEmployeePaymentTypeToHoldCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
        
        public override bool Equals(object obj)
        {
            var changeEmployeePaymentTypeToHoldCommand = obj as ChangeEmployeePaymentTypeToHoldCommand;

            if (ReferenceEquals(changeEmployeePaymentTypeToHoldCommand, null))
                return false;

            return Id == changeEmployeePaymentTypeToHoldCommand.Id;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() => $"{nameof(ChangeEmployeePaymentTypeToHoldCommand)} {{ {nameof(Id)}: {Id} }}";
    }
}