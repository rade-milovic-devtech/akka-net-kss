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

                if (!AreValid(arguments))
                    throw new ChangeEmployeeToHourlyCommandStructureException();
            
                return new ChangeEmployeeToHourlyCommand(GetIdFrom(arguments), GetHourlyRateFrom(arguments));
            }
            catch (ChangeEmployeeToHourlyCommandStructureException) { throw; }
            catch (Exception ex)
            {
                throw new ChangeEmployeeToHourlyCommandStructureException(ex);
            }
        }

        private static bool AreValid(string[] arguments) =>
            arguments.Length == 3 &&
            ChangeTypeIsHourlyEmployeeType(arguments);

        private static bool ChangeTypeIsHourlyEmployeeType(string[] arguments) =>
            string.Equals(GetChangeTypeFrom(arguments), HourlyEmployeeType, StringComparison.InvariantCultureIgnoreCase);
        
        private static string GetChangeTypeFrom(string[] arguments) => arguments[1];
        
        private static int GetIdFrom(string[] arguments) => int.Parse(arguments[0]);

        private static decimal GetHourlyRateFrom(string[] arguments) => decimal.Parse(arguments[2]);
    }
}