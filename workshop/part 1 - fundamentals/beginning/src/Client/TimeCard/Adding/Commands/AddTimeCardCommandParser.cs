using System;
using System.Linq;

namespace AkkaPayroll.Client.TimeCard.Adding.Commands
{
    public class AddTimeCardCommandParser
    {
        public static AddTimeCardCommand Parse(string command)
        {
            var timeCardTokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Where(token => !string.IsNullOrWhiteSpace(token))
                                        .ToArray();

            try
            {
                var employeeId = int.Parse(timeCardTokens[1]);
                var date = DateParser.Parse(timeCardTokens[2]);
                var hours = int.Parse(timeCardTokens[3]);

                return new AddTimeCardCommand(employeeId, date, hours);
            }
            catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
            {
                throw new AddTimeCardCommandStructureException(ex);
            }
        }
    }
}
