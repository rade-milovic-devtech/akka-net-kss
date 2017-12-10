using System;
using AkkaPayroll.Client.Common;

namespace AkkaPayroll.Client.Payroll.Running
{
    public static class RunPayrollCommandParser
    {
        public static RunPayrollCommand Parse(string command)
        {
            try
            {
                var arguments = CommandsArgumentsExtractor.ExtractFrom(command);

                if (!AreValid(arguments))
                    throw new RunPayrollCommandStructureException();

                return new RunPayrollCommand(GetDateFrom(arguments));
            }
            catch (RunPayrollCommandStructureException) { throw; }
            catch (Exception ex)
            {
                throw new RunPayrollCommandStructureException(ex);
            }
        }
        
        private static bool AreValid(string[] arguments) => arguments.Length == 1;

        private static DateTime GetDateFrom(string[] arguments) => DateParser.Parse(arguments[0]);
    }
}