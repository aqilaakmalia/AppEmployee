using System;

namespace AppEmployee.DTOs
{
    public class BaseResponse<T>
    {
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Status { get; set; }
        public T? Data { get; set; }

        public BaseResponse(int code, string message, bool status, T? data)
        {
            Code = code;
            Message = message;
            Status = status;
            Data = data;
        }

        public static BaseResponse<T> Success(int code, string message, T? data)
        {
            return new BaseResponse<T>(code, message, true, data);
        }

        public static BaseResponse<T> Failure(int code, string message)
        {
            return new BaseResponse<T>(code, message, false, default);
        }
    }
}
