using System;
using System.Linq;

namespace AkkaPayroll.Client.Employee.Changing
{
    public static class ConvertEmployeeToHourlyCommandParser
    {
        private const string HourlyPaymentType = "hourly";
        
        public static ConvertEmployeeToHourlyCommand Parse(string command)
        {
            try
            {
                var arguments = GetArgumentsFor(command);

                Validate(arguments);
            
                return new ConvertEmployeeToHourlyCommand(GetIdFrom(arguments), GetHourlyRateFrom(arguments));
            }
            catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
            {
                throw new ConvertEmployeeToHourlyCommandStructureException(ex);
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
                throw new ConvertEmployeeToHourlyCommandStructureException();
            
            var changeType = GetChangeTypeFrom(arguments);
            if (!string.Equals(changeType, HourlyPaymentType, StringComparison.InvariantCultureIgnoreCase))
                throw new ConvertEmployeeToHourlyCommandStructureException();
        }

        private static string GetChangeTypeFrom(string[] arguments) => arguments[1];
        
        private static int GetIdFrom(string[] arguments) => int.Parse(arguments[0]);

        private static decimal GetHourlyRateFrom(string[] arguments) => decimal.Parse(arguments[2]);
    }
}