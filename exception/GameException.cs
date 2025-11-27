using consoleApp.@enum;

namespace consoleApp.exception
{
    public class GameException : Exception
    {
        public ErrorCode Code { get; }

        public GameException(ErrorCode errorCode) : base(errorCode.Message)
        {
            Code = errorCode;
        }
    }
}