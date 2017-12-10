using System;
using AkkaPayroll.Client.Common;

namespace AkkaPayroll.Client.ServiceCharge.Posting
{
	public static class PostServiceChargeCommandParser
	{
		public static PostServiceChargeCommand Parse(string command)
		{
			try
			{
				var arguments = CommandsArgumentsExtractor.ExtractFrom(command);

				if (!AreValid(arguments))
					throw new PostServiceChargeCommandStructureException();

				return new PostServiceChargeCommand(GetMemberIdFrom(arguments), GetAmountFrom(arguments));
			}
			catch (PostServiceChargeCommandStructureException) { throw; }
			catch (Exception ex)
			{
				throw new PostServiceChargeCommandStructureException(ex);
			}
		}

		private static bool AreValid(string[] arguments) => arguments.Length == 2;

		private static int GetMemberIdFrom(string[] arguments) => int.Parse(arguments[0]);

		private static decimal GetAmountFrom(string[] arguments) => decimal.Parse(arguments[1]);
	}
}