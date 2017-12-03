using System;
using System.Linq;

namespace AkkaPayroll.Client.Employee.Changing
{
    public static class ChangeEmployeeToCommissionedCommandParser
    {
        private const string CommissionedEmployeeType = "commissioned";
        
        public static ChangeEmployeeToCommissionedCommand Parse(string command)
        {
            try
            {
                var arguments = GetArgumentsFor(command);
            
                Validate(arguments);
            
                return new ChangeEmployeeToCommissionedCommand(
                    GetIdFrom(arguments),
                    GetMonthlySalaryFrom(arguments),
                    GetCommissionRateFrom(arguments));
            }
            catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
            {
                throw new ChangeEmployeeToCommissionedCommandStructureException(ex);
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
            if (arguments.Length > 4)
                throw new ChangeEmployeeToCommissionedCommandStructureException();
            
            var changeType = GetChangeTypeFrom(arguments);
            if (!string.Equals(changeType, CommissionedEmployeeType, StringComparison.InvariantCultureIgnoreCase))
                throw new ChangeEmployeeToCommissionedCommandStructureException();
        }
        
        private static string GetChangeTypeFrom(string[] arguments) => arguments[1];
        
        private static int GetIdFrom(string[] arguments) => int.Parse(arguments[0]);

        private static decimal GetMonthlySalaryFrom(string[] arguments) => decimal.Parse(arguments[2]);

        private static decimal GetCommissionRateFrom(string[] arguments) => decimal.Parse(arguments[3]);
    }
}