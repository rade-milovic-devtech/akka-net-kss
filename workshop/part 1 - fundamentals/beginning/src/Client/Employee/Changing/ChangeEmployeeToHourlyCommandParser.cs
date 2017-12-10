using System;
using AkkaPayroll.Client.Common;

namespace AkkaPayroll.Client.Employee.Changing
{
    public static class ChangeEmployeeToHourlyCommandParser
    {
        private const string HourlyEmployeeType = "hourly";
        
        public static ChangeEmployeeToHourlyCommand Parse(string command)
        {
            try
            {
                var arguments = CommandsArgumentsExtractor.ExtractFrom(command);

                Validate(arguments);
            
                return new ChangeEmployeeToHourlyCommand(GetIdFrom(arguments), GetHourlyRateFrom(arguments));
            }
            catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
            {
                throw new ChangeEmployeeToHourlyCommandStructureException(ex);
            }
        }

        private static void Validate(string[] arguments)
        {
            if (arguments.Length > 3)
                throw new ChangeEmployeeToHourlyCommandStructureException();
            
            var changeType = GetChangeTypeFrom(arguments);
            if (!string.Equals(changeType, HourlyEmployeeType, StringComparison.InvariantCultureIgnoreCase))
                throw new ChangeEmployeeToHourlyCommandStructureException();
        }

        private static string GetChangeTypeFrom(string[] arguments) => arguments[1];
        
        private static int GetIdFrom(string[] arguments) => int.Parse(arguments[0]);

        private static decimal GetHourlyRateFrom(string[] arguments) => decimal.Parse(arguments[2]);
    }
}