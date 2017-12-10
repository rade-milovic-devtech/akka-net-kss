using System;
using AkkaPayroll.Client.Common;

namespace AkkaPayroll.Client.Employee.Changing
{
    public static class ChangeEmployeeToCommissionedCommandParser
    {
        private const string CommissionedEmployeeType = "commissioned";
        
        public static ChangeEmployeeToCommissionedCommand Parse(string command)
        {
            try
            {
                var arguments = CommandsArgumentsExtractor.ExtractFrom(command);
            
                if (!AreValid(arguments))
                    throw new ChangeEmployeeToCommissionedCommandStructureException();
            
                return new ChangeEmployeeToCommissionedCommand(
                    GetIdFrom(arguments),
                    GetMonthlySalaryFrom(arguments),
                    GetCommissionRateFrom(arguments));
            }
            catch (ChangeEmployeeToCommissionedCommandStructureException) { throw; }
            catch (Exception ex)
            {
                throw new ChangeEmployeeToCommissionedCommandStructureException(ex);
            }
        }
        
        private static bool AreValid(string[] arguments) =>
            arguments.Length == 4 &&
            ChangeTypeIsCommissionedEmployeeType(arguments);

        private static bool ChangeTypeIsCommissionedEmployeeType(string[] arguments) =>
            string.Equals(GetChangeTypeFrom(arguments), CommissionedEmployeeType, StringComparison.InvariantCultureIgnoreCase);
        
        private static string GetChangeTypeFrom(string[] arguments) => arguments[1];
        
        private static int GetIdFrom(string[] arguments) => int.Parse(arguments[0]);

        private static decimal GetMonthlySalaryFrom(string[] arguments) => decimal.Parse(arguments[2]);

        private static decimal GetCommissionRateFrom(string[] arguments) => decimal.Parse(arguments[3]);
    }
}