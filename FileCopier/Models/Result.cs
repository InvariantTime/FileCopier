
namespace FileCopier.Models
{
    public class Result
    {
        private static readonly Result _success = new(true, string.Empty);

        public bool IsSuccess { get; }

        public string Message { get; }

        private Result(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public static Result Success()
        {
            return _success;
        }

        public static Result Failure(string message)
        {
            return new Result(false, message);
        }
    }
}
