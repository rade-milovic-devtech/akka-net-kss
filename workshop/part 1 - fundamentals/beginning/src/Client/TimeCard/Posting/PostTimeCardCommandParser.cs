﻿using System;
using System.Linq;
using AkkaPayroll.Client.Common;

namespace AkkaPayroll.Client.TimeCard.Posting
{
	public static class PostTimeCardCommandParser
	{
		public static PostTimeCardCommand Parse(string command)
		{
			var arguments = GetArgumentsFor(command);

			Validate(arguments);

			try
			{
				var employeeId = GetEmployeeIdFrom(arguments);
				var date = GetDateFrom(arguments);
				var hours = GetHoursFrom(arguments);

				return new PostTimeCardCommand(employeeId, date, hours);
			}
			catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
			{
				throw new PostTimeCardCommandStructureException(ex);
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
			if (arguments.Length > 3)
				throw new PostTimeCardCommandStructureException();
		}

		private static int GetEmployeeIdFrom(string[] arguments) => int.Parse(arguments[0]);

		private static DateTime GetDateFrom(string[] arguments) => DateParser.Parse(arguments[1]);

		private static int GetHoursFrom(string[] arguments) => int.Parse(arguments[2]);
	}
}