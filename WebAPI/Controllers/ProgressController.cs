using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressController : ControllerBase
    {

        private static ConcurrentDictionary<Guid, Result> _queryResults = new(2, 1);
        private static IProgress<Result>? _progress;

        [HttpGet("startprocess")]
        public IActionResult StartProcess()
        {
            Guid id = Guid.NewGuid();
            Task.Run(() => QueryToDB(id, _progress));
            return Ok(id);
        }

        [HttpGet("getprocessstate")]
        public IActionResult? GetProcessState(Guid id)
        {
            bool processStateExists = _queryResults.TryGetValue(id, out Result? processResult);
            return Ok(processResult);
        }

        private async Task QueryToDB(Guid id, IProgress<Result>? progress)
        {
            Result processCurrentResult = new()
            {
                ProcessState = ProcessState.Active,
                Message = Messages.QueryActive,
            };

            try
            {
                await Task.Run(() =>
                 {
                     for (int i =1; i <= 5; i ++)
                     {
                         _queryResults.AddOrUpdate(id, processCurrentResult,
                             (key, previousResult) => new Result()
                             {
                                 ProcessState = ProcessState.Active,
                                 Message = Messages.QueryActive,
                                 Progress = i
                             });

                         Thread.Sleep(1000); // => represents long running query
                     }
                 });

                _queryResults.AddOrUpdate(id, processCurrentResult,
                             (key, previousResult) => new Result()
                             {
                                 ProcessState = ProcessState.Succeeded,
                                 Message = Messages.QuerySucceeded,
                                 Progress = 1
                             });
            }
            catch (Exception)
            {
                Result processResult = new()
                {
                    ProcessState = ProcessState.Failed,
                    Message = Messages.QueryFailed,
                };
                _queryResults.AddOrUpdate(id, processCurrentResult,
                             (key, previousResult) => new Result()
                             {
                                 ProcessState = ProcessState.Active,
                                 Message = Messages.QueryActive,
                             });
            }
        }
    }
}
