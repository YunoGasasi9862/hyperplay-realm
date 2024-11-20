using BLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Load
{
    public class Result: IResult
    {
        private const string DEFAULT_MESSAGE = "UNKNOWN";
        public string? Message { get; set; }

        public bool IsSuccessfull { get; set; }

        private readonly Dictionary<ResultEnum, string> resultMessages = new Dictionary<ResultEnum, string>()
        {
            {ResultEnum.ERROR, "Failed to perform the Operation"},

            {ResultEnum.SUCCESS, "Successfully performed the Operation"},
        };

        public void SetResultMessage(ResultEnum result, bool isSuccessful)
        {
            Message = resultMessages.TryGetValue(result, out var resultMessage) ? resultMessage : DEFAULT_MESSAGE;

            IsSuccessfull = isSuccessful;
        }
    }
}
