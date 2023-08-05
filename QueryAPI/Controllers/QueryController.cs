using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace QueryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        private ConcurrentDictionary<Guid, IResult> _queryStates; 
        public QueryController()
        {
              _queryStates = new ConcurrentDictionary<Guid, IResult>();
        }

        [HttpGet]
        public IActionResult Get()
        {


            return Ok();
        }
    }
}
