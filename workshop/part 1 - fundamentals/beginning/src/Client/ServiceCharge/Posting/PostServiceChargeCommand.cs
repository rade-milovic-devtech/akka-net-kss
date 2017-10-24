namespace AkkaPayroll.Client.ServiceCharge.Posting
{
	public class PostServiceChargeCommand
	{
		public PostServiceChargeCommand(int memberId, decimal amount)
		{
			MemberId = memberId;
			Amount = amount;
		}

		public int MemberId { get; }
		public decimal Amount { get; }

		public override bool Equals(object obj)
		{
			var postServiceChargeCommand = obj as PostServiceChargeCommand;

			if (ReferenceEquals(postServiceChargeCommand, null)) return false;

			return MemberId == postServiceChargeCommand.MemberId
				&& Amount == postServiceChargeCommand.Amount;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = MemberId.GetHashCode();
				hashCode = (hashCode * 397) ^ Amount.GetHashCode();

				return hashCode;
			}
		}

		public override string ToString() =>
			$"{nameof(PostServiceChargeCommand)} {{ {nameof(MemberId)}: {MemberId}, {nameof(Amount)}: {Amount} }}";
	}
}