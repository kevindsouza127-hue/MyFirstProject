namespace Labcare.Master.Controllers
{
    public static class ResponseStatus
    {
        public static readonly string Success = "true";
        public static readonly string Failure = "false";
    }
    public static class StatusCodes
    {
        // Predefined
        public static readonly int OK = 200;

        public static readonly int BadRequest = 400;
        public static readonly int Unauthorized = 401;
        public static readonly int Forbidden = 403;
        public static readonly int NotAcceptable = 406;
        public static readonly int Conflict = 409;   // Duplicate Records. Need to remove this. Used in some screens

        public static readonly int APIModelValidations = 420;   // Model class Related Errors
        public static readonly int DuplicateRecord = 430;  // Duplicate and All API Level Errors
        public static readonly int NoRecordsFound = 440;

        public static readonly int DatabaseException = 590;      // DB level Errors
        public static readonly int APIException = 690;  // API level Errors
        public static readonly int PermissionNotAllowed = 404; // Menu permission not Found - Unauthorized menu access
        // public static readonly int DuplicateRecord = 801;  // Need to remove this. Used in some screens

        public static readonly int PasswordExpired = 419; // password expired
        public static readonly int UnauthorizedWithWarning = 427; // Unauthorized with warning
        public static readonly int NoDataUpdated = 500;
        public static readonly int DataUpdated = 500;


    }
}
