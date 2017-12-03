using System;
using System.Linq;

namespace AkkaPayroll.Client.Employee.Changing
{
    public static class ChangeEmployeeToSalariedCommandParser
    {
        private const string SalariedEmployeeType = "salaried";
        
        public static ChangeEmployeeToSalariedCommand Parse(string command)
        {
            try
            {
                var arguments = GetArgumentsFor(command);
            
                Validate(arguments);
                
                return new ChangeEmployeeToSalariedCommand(GetIdFrom(arguments), GetMonthlySalaryFrom(arguments));
            }
            catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
            {
                throw new ChangeEmployeeToSalariedCommandStructureException(ex);
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
                throw new ChangeEmployeeToSalariedCommandStructureException();
            
            var changeType = GetChangeTypeFrom(arguments);
            if (!string.Equals(changeType, SalariedEmployeeType, StringComparison.InvariantCultureIgnoreCase))
                throw new ChangeEmployeeToSalariedCommandStructureException();
        }
        
        private static string GetChangeTypeFrom(string[] arguments) => arguments[1];
        
        private static int GetIdFrom(string[] arguments) => int.Parse(arguments[0]);

        private static decimal GetMonthlySalaryFrom(string[] arguments) => decimal.Parse(arguments[2]);
    }
}