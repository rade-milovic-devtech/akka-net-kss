using System;

namespace AkkaPayroll.Client.Employee.Changing
{
    public class ChangeEmployeePaymentTypeToDirectCommand
    {
        public ChangeEmployeePaymentTypeToDirectCommand(int id, string bank, string account)
        {
            Id = id;
            Bank = bank;
            Account = account;
        }
        
        public int Id { get; }
        public string Bank { get; }
        public string Account { get; }
        
        public override bool Equals(object obj)
        {
            var changeEmployeePaymentTypeToDirectCommand = obj as ChangeEmployeePaymentTypeToDirectCommand;

            if (ReferenceEquals(changeEmployeePaymentTypeToDirectCommand, null))
                return false;

            return Id == changeEmployeePaymentTypeToDirectCommand.Id
                   && string.Equals(Bank, changeEmployeePaymentTypeToDirectCommand.Bank, StringComparison.InvariantCultureIgnoreCase)
                   && string.Equals(Account, changeEmployeePaymentTypeToDirectCommand.Account, StringComparison.InvariantCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ Bank.GetHashCode();
                hashCode = (hashCode * 397) ^ Account.GetHashCode();

                return hashCode;
            }
        }

        public override string ToString() =>
            $"{nameof(ChangeEmployeePaymentTypeToDirectCommand)} {{ {nameof(Id)}: {Id}, {nameof(Bank)}: {Bank}, {nameof(Account)}: {Account} }}";
    }
}