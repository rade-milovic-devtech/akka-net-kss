namespace AkkaPayroll.Client.Employee.Changing
{
    public class ChangeEmployeeToNonUnionMemberCommand
    {
        public ChangeEmployeeToNonUnionMemberCommand(int id)
        {
            Id = id;
        }
        
        public int Id { get; }
        
        public override bool Equals(object obj)
        {
            var changeEmployeeToNonUnionMemberCommand = obj as ChangeEmployeeToNonUnionMemberCommand;

            if (ReferenceEquals(changeEmployeeToNonUnionMemberCommand, null)) return false;

            return Id == changeEmployeeToNonUnionMemberCommand.Id;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() => $"{nameof(ChangeEmployeeToNonUnionMemberCommand)} {{ {nameof(Id)}: {Id} }}";
    }
}