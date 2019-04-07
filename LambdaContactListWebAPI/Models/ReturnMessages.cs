using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambdaContactListWebAPI.Models
{
    public class ReturnMessage
    {
        public string Message { get; }
        public bool Error { get; }
        public ReturnMessage(bool error, string message)
        {
            Error = error;
            Message = message;
        }
    }
}
