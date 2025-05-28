using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Result
{
    public class Result<T>
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }
        public Result() { }
        public Result(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
        public Result(bool success, string errorMessage)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }
    }
}
