using System;
using System.Linq;
using AkkaPayroll.Client.Common;

namespace AkkaPayroll.Client.SalesReceipt.Adding.Commands
{
    public static class AddSalesReceiptCommandParser
    {
        public static AddSalesReceiptCommand Parse(string command)
        {
            var timeCardTokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(token => !string.IsNullOrWhiteSpace(token))
                .ToArray();

            var employeeId = int.Parse(timeCardTokens[1]);
            var date = DateParser.Parse(timeCardTokens[2]);
            var amount = decimal.Parse(timeCardTokens[3]);

            return new AddSalesReceiptCommand(employeeId, date, amount);
        }
    }
}