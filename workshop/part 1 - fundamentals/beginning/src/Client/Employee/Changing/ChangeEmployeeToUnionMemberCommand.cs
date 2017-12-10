namespace AkkaPayroll.Client.Employee.Changing
{
    public class ChangeEmployeeToUnionMemberCommand
    {   
        public ChangeEmployeeToUnionMemberCommand(int id, int memberId, decimal commissionRate)
        {
            Id = id;
            MemberId = memberId;
            CommissionRate = commissionRate;
        }
        
        public int Id { get; }
        public int MemberId { get; }
        public decimal CommissionRate { get; }
        
        public override bool Equals(object obj)
        {
            var changeEmployeeToUnionMemberCommand = obj as ChangeEmployeeToUnionMemberCommand;

            if (ReferenceEquals(changeEmployeeToUnionMemberCommand, null)) return false;

            return Id == changeEmployeeToUnionMemberCommand.Id
                   && MemberId == changeEmployeeToUnionMemberCommand.MemberId
                   && CommissionRate == changeEmployeeToUnionMemberCommand.CommissionRate;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ MemberId.GetHashCode();
                hashCode = (hashCode * 397) ^ CommissionRate.GetHashCode();

                return hashCode;
            }
        }

        public override string ToString() =>
            $"{nameof(ChangeEmployeeToUnionMemberCommand)} {{ {nameof(Id)}: {Id}, {nameof(MemberId)}: {MemberId}, {nameof(CommissionRate)}: {CommissionRate} }}";
    }
}