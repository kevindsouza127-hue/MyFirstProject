using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Labcare.Master.Helpers
{
    public class Response
    {
        public int? Id { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string EncryptedReturnId { get; set; }
    }
    public class Response<T>
    {
        public Response(T data, string success, int statusCode, string message = null)
        {
            Success = success;
            StatusCode = statusCode;
            TimeStamp = DateTime.Now;
            if (string.IsNullOrEmpty(message) && data == null)
                Message = "No records found.";
            else
                Message = message;
            Data = data;


        }

        public Response(string success, int statusCode, string message = null)
        {
            Success = success;
            StatusCode = statusCode;
            Message = message;
            TimeStamp = DateTime.Now;
        }

        public string Success { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Version { get; set; } = "V.1.0036";
    }


}
