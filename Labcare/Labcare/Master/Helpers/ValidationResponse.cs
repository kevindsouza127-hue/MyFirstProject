namespace Labcare.Master.Helpers
{
    public class ValidationResponse
    {
        public string success { get; set; }
        public int statusCode { get; set; }
        public string message { get; set; }
        public ValidationResponseData data { get; set; }
    }
    public class ValidationResponseData
    {
        public List<ErrorResponse> Errors { get; set; }
    }

    public class ErrorResponse
    {
        public string ErrorField { get; set; }
        public string ErrorDescription { get; set; }
    }
    public class TokenValidationResponse
    {
        public string success { get; set; }
        public int statusCode { get; set; }
        public string message { get; set; }
    }
    public class MenuValidationRequest
    {
        public string Menu { get; set; }
        public string Actions { get; set; }
    }
}
