using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Text.Json;
using WebAPI;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        private static ConcurrentDictionary<Guid, Result> _queryResults = new(2, 1);

        [HttpGet("startprocess")]
        public IActionResult StartProcess()
        {
            Guid id = Guid.NewGuid();
            Task.Run(() => QueryToDB(id));
            return Ok(id);
        }

        [HttpGet("getprocessstate")]
        public IActionResult? GetProcessState(Guid id)
        {

            bool processStateExists = _queryResults.TryGetValue(id, out Result? processResult);
            if (processStateExists)
            {
                //string resultJson = JsonSerializer.Serialize(processResult);
                return Ok(processResult);
            }
            else
            {
                Result failedResult = new() { Message = Messages.QueryFailed, ProcessState = ProcessState.Failed };
                return Ok(failedResult);
            }
        }

        private async Task QueryToDB(Guid id)
        {
            Result processCurrentResult = new()
            {
                ProcessState = ProcessState.Active,
                Message = Messages.QueryActive
            };
            try
            {
                bool isAdded = _queryResults.TryAdd(id, processCurrentResult);
                await Task.Delay(5000); /*=> represents long running query */
                Result processResult = new()
                {
                    ProcessState = ProcessState.Succeeded,
                    Message = Messages.QuerySucceeded,
                };
                _queryResults.TryUpdate(id, processResult, processCurrentResult);
            }
            catch (Exception)
            {
                Result processResult = new()
                {
                    ProcessState = ProcessState.Failed,
                    Message = Messages.QueryFailed,
                };
                _queryResults.TryUpdate(id, processResult, processCurrentResult);
            }
        }
    }
}






/*
 private static ConcurrentDictionary<Guid, Result> _queryResults = new(2, 1);
        private static IProgress<int> _progress;

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
            if (processStateExists)
            {
                //string resultJson = JsonSerializer.Serialize(processResult);
                return Ok(processResult);
            }
            else
            {
                Result failedResult = new() { Message = Messages.QueryFailed, ProcessState = ProcessState.Failed };
                return Ok(failedResult);
            }
        }

        private async Task QueryToDB(Guid id, IProgress<int> progress)
        {
            Result processCurrentResult = new()
            {
                ProcessState = ProcessState.Active,
                Message = Messages.QueryActive
            };
            try
            {
                bool isAdded = _queryResults.TryAdd(id, processCurrentResult);
                await Task.Run(() =>
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        progress.Report(i);
                        Thread.Sleep(1000);
                    };

                }); 
Result processResult = new()
{
    ProcessState = ProcessState.Succeeded,
    Message = Messages.QuerySucceeded,
};
_queryResults.TryUpdate(id, processResult, processCurrentResult);
            }
            catch (Exception)
            {
    Result processResult = new()
    {
        ProcessState = ProcessState.Failed,
        Message = Messages.QueryFailed,
    };
    _queryResults.TryUpdate(id, processResult, processCurrentResult);
}


*/