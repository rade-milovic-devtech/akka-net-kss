using System;
using AkkaPayroll.Client.Common;

namespace AkkaPayroll.Client.Employee.Changing
{
    public static class ChangeEmployeeToSalariedCommandParser
    {
        private const string SalariedEmployeeType = "salaried";
        
        public static ChangeEmployeeToSalariedCommand Parse(string command)
        {
            try
            {
                var arguments = CommandsArgumentsExtractor.ExtractFrom(command);
            
                if (!AreValid(arguments))
                    throw new ChangeEmployeeToSalariedCommandStructureException();
                
                return new ChangeEmployeeToSalariedCommand(GetIdFrom(arguments), GetMonthlySalaryFrom(arguments));
            }
            catch (ChangeEmployeeToSalariedCommandStructureException) { throw; }
            catch (Exception ex)
            {
                throw new ChangeEmployeeToSalariedCommandStructureException(ex);
            }
        }

        private static bool AreValid(string[] arguments) =>
            arguments.Length == 3 &&
            ChangeTypeIsSalariedEmployeeType(arguments);

        private static bool ChangeTypeIsSalariedEmployeeType(string[] arguments) =>
            string.Equals(GetChangeTypeFrom(arguments), SalariedEmployeeType, StringComparison.InvariantCultureIgnoreCase);
        
        private static string GetChangeTypeFrom(string[] arguments) => arguments[1];
        
        private static int GetIdFrom(string[] arguments) => int.Parse(arguments[0]);

        private static decimal GetMonthlySalaryFrom(string[] arguments) => decimal.Parse(arguments[2]);
    }
}