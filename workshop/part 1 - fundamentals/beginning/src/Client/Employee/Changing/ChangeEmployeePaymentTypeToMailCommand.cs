using System;

namespace AkkaPayroll.Client.Employee.Changing
{
    public class ChangeEmployeePaymentTypeToMailCommand
    {
        public ChangeEmployeePaymentTypeToMailCommand(int id, string address)
        {
            Id = id;
            Address = address;
        }
        
        public int Id { get; }
        public string Address { get; }
        
        public override bool Equals(object obj)
        {
            var changeEmployeePaymentTypeToMailCommand = obj as ChangeEmployeePaymentTypeToMailCommand;

            if (ReferenceEquals(changeEmployeePaymentTypeToMailCommand, null))
                return false;

            return Id == changeEmployeePaymentTypeToMailCommand.Id &&
                   string.Equals(Address, changeEmployeePaymentTypeToMailCommand.Address, StringComparison.InvariantCultureIgnoreCase);
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

        public override string ToString() => $"{nameof(ChangeEmployeePaymentTypeToMailCommand)} {{ {nameof(Id)}: {Id}, {nameof(Address)}: {Address} }}";
    }
}