using System;
using System.Linq;

namespace AkkaPayroll.Client.Employee.Changing
{
    public static class ChangeEmployeeToHourlyCommandParser
    {
        private const string HourlyPaymentType = "hourly";
        
        public static ChangeEmployeeToHourlyCommand Parse(string command)
        {
            try
            {
                var arguments = GetArgumentsFor(command);

                Validate(arguments);
            
                return new ChangeEmployeeToHourlyCommand(GetIdFrom(arguments), GetHourlyRateFrom(arguments));
            }
            catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
            {
                throw new ChangeEmployeeToHourlyCommandStructureException(ex);
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
                throw new ChangeEmployeeToHourlyCommandStructureException();
            
            var changeType = GetChangeTypeFrom(arguments);
            if (!string.Equals(changeType, HourlyPaymentType, StringComparison.InvariantCultureIgnoreCase))
                throw new ChangeEmployeeToHourlyCommandStructureException();
        }

        private static string GetChangeTypeFrom(string[] arguments) => arguments[1];
        
        private static int GetIdFrom(string[] arguments) => int.Parse(arguments[0]);

        private static decimal GetHourlyRateFrom(string[] arguments) => decimal.Parse(arguments[2]);
    }
}