using System;
using System.Linq;

namespace AkkaPayroll.Client.Common
{
	public static class DateParser
	{
		public static DateTime Parse(string date)
		{
			var dateTokens = date.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
				.Where(token => !string.IsNullOrWhiteSpace(token))
				.ToArray();

			return new DateTime(int.Parse(dateTokens[2]), int.Parse(dateTokens[1]), int.Parse(dateTokens[0]));
		}
	}
}