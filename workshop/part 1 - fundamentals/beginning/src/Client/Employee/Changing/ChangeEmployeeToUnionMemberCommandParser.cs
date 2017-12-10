using System;
using AkkaPayroll.Client.Common;

namespace AkkaPayroll.Client.Employee.Changing
{
    public static class ChangeEmployeeToUnionMemberCommandParser
    {
        private const string PutEmployeeInUnionChangeType = "member";
        
        public static ChangeEmployeeToUnionMemberCommand Parse(string command)
        {
            try
            {
                var arguments = CommandsArgumentsExtractor.ExtractFrom(command);
            
                if (!AreValid(arguments))
                    throw new ChangeEmployeeToUnionMemberCommandStructureException();
            
                return new ChangeEmployeeToUnionMemberCommand(
                    GetIdFrom(arguments),
                    GetMemberIdFrom(arguments),
                    GetCommissionRateFrom(arguments));
            }
            catch (ChangeEmployeeToUnionMemberCommandStructureException) { throw; }
            catch (Exception ex)
            {
                throw new ChangeEmployeeToUnionMemberCommandStructureException(ex);
            }
        }
        
        private static bool AreValid(string[] arguments) =>
            arguments.Length == 5 &&
            ChangeTypeIsPutEmployeeInUnion(arguments) &&
            string.Equals(arguments[3], "dues", StringComparison.InvariantCultureIgnoreCase);

        private static bool ChangeTypeIsPutEmployeeInUnion(string[] arguments) =>
            string.Equals(GetChangeTypeFrom(arguments), PutEmployeeInUnionChangeType, StringComparison.InvariantCultureIgnoreCase);
        
        private static string GetChangeTypeFrom(string[] arguments) => arguments[1];
        
        private static int GetIdFrom(string[] arguments) => int.Parse(arguments[0]);

        private static int GetMemberIdFrom(string[] arguments) => int.Parse(arguments[2]);

        private static decimal GetCommissionRateFrom(string[] arguments) => decimal.Parse(arguments[4]);
    }
}