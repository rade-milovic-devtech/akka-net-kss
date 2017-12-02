using System;
using System.Linq;

namespace AkkaPayroll.Client.ServiceCharge.Posting
{
	public static class PostServiceChargeCommandParser
	{
		public static PostServiceChargeCommand Parse(string command)
		{
			try
			{
				var arguments = GetArgumentsFor(command);

				Validate(arguments);

				return new PostServiceChargeCommand(GetMemberIdFrom(arguments), GetAmountFrom(arguments));
			}
			catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
			{
				throw new PostServiceChargeCommandStructureException(ex);
			}
		}

		private static string[] GetArgumentsFor(string command)
		{
			var commandTokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);;

			return commandTokens.Where(token => !string.IsNullOrWhiteSpace(token))
				.Skip(1)
				.ToArray();
		}

		private static void Validate(string[] arguments)
		{
			if (arguments.Length > 2)
				throw new PostServiceChargeCommandStructureException();
		}

		private static int GetMemberIdFrom(string[] arguments) => int.Parse(arguments[0]);

		private static decimal GetAmountFrom(string[] arguments) => decimal.Parse(arguments[1]);
	}
}