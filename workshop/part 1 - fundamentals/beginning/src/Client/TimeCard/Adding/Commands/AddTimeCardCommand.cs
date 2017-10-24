using System;

namespace AkkaPayroll.Client.TimeCard.Adding.Commands
{
	public class AddTimeCardCommand
	{
		private int employeeId;
		private DateTime date;
		private int hours;

		public AddTimeCardCommand(int employeeId, DateTime date, int hours)
		{
			this.employeeId = employeeId;
			this.date = date;
			this.hours = hours;
		}

		public override bool Equals(object obj)
		{
			var addTimeCardCommand = obj as AddTimeCardCommand;

			if (ReferenceEquals(addTimeCardCommand, null)) return false;

			return employeeId == addTimeCardCommand.employeeId
					&& date == addTimeCardCommand.date
					&& hours == addTimeCardCommand.hours;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = employeeId.GetHashCode();
				hashCode = (hashCode * 397) ^ date.GetHashCode();
				hashCode = (hashCode * 397) ^ hours.GetHashCode();

				return hashCode;
			}
		}

		public override string ToString() =>
			$"{nameof(AddTimeCardCommand)} {{ {nameof(employeeId)}: {employeeId}, {nameof(date)}: {date}, {nameof(hours)}: {hours} }}";
	}
}
