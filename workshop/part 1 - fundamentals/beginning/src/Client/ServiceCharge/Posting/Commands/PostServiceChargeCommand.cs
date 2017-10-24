namespace AkkaPayroll.Client.ServiceCharge.Posting.Commands
{
	public class PostServiceChargeCommand
	{
		private int memberId;
		private decimal amount;

		public PostServiceChargeCommand(int memberId, decimal amount)
		{
			this.memberId = memberId;
			this.amount = amount;
		}

		public override bool Equals(object obj)
		{
			var postServiceChargeCommand = obj as PostServiceChargeCommand;

			if (ReferenceEquals(postServiceChargeCommand, null)) return false;

			return memberId == postServiceChargeCommand.memberId
				&& amount == postServiceChargeCommand.amount;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = memberId.GetHashCode();
				hashCode = (hashCode * 397) ^ amount.GetHashCode();

				return hashCode;
			}
		}

		public override string ToString() =>
			$"{nameof(PostServiceChargeCommand)} {{ {nameof(memberId)}: {memberId}, {nameof(amount)}: {amount} }}";
	}
}