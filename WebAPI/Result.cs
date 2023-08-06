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
        public int Progress { get; set; } = 0;
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
