using System;

namespace AkkaPayroll.Client.TimeCard.Posting
{
	public class PostTimeCardCommand
	{
		public PostTimeCardCommand(int employeeId, DateTime date, int hours)
		{
			EmployeeId = employeeId;
			Date = date;
			Hours = hours;
		}

		public int EmployeeId { get; }
		public DateTime Date { get; }
		public int Hours { get; }

		public override bool Equals(object obj)
		{
			var postTimeCardCommand = obj as PostTimeCardCommand;

			if (ReferenceEquals(postTimeCardCommand, null)) return false;

			return EmployeeId == postTimeCardCommand.EmployeeId
				&& Date == postTimeCardCommand.Date
				&& Hours == postTimeCardCommand.Hours;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = EmployeeId.GetHashCode();
				hashCode = (hashCode * 397) ^ Date.GetHashCode();
				hashCode = (hashCode * 397) ^ Hours.GetHashCode();

				return hashCode;
			}
		}

		public override string ToString() =>
			$"{nameof(PostTimeCardCommand)} {{ {nameof(EmployeeId)}: {EmployeeId}, {nameof(Date)}: {Date}, {nameof(Hours)}: {Hours} }}";
	}
}