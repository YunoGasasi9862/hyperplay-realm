using BLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Load
{
    public class ResultMessages
    {
        private const string DEFAULT_MESSAGE = "UNKNOWN";

        private readonly Dictionary<Result, string> resultMessages = new Dictionary<Result, string>()
        {
            {Result.ERROR, "Failed to perform the Operation"},

            {Result.SUCCESS, "Successfully performed the Operation"},
        };

        public string GetResultMessage(Result result)
        {
            return resultMessages.TryGetValue(result, out var resultMessage) ? resultMessage : DEFAULT_MESSAGE;
        }
    }
}
