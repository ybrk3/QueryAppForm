using System.Text.Json.Serialization;

namespace WebAPI
{
    public class Result
    {
        public Result()
        {
            
        }
        public ProcessState ProcessState { get; set; }
        public string Message { get; set; }
    }

    [Flags]
    public enum ProcessState
    {
        None = 0,
        Active = 1,
        Succeeded = 2,
        Failed = 3
    }
}
