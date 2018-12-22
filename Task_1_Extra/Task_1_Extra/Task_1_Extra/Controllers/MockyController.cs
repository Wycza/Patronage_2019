using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_1_Extra.Application.Mockies.Queries;

namespace Task_1_Extra.Controllers
{
    /// <summary>
    /// Mocky controller
    /// </summary>
    [ApiController]
    public class MockyController : BaseController
    {
        /// <summary>
        /// This endpoint returns response from http://www.mocky.io/v2/5c127054330000e133998f85
        /// </summary>
        /// <returns>Response from http://www.mocky.io/v2/5c127054330000e133998f85 </returns>
        [HttpGet]
        [Produces("text/plain")]
        public async Task<ActionResult<string>> GetResponseFromMocky()
        {
            return Ok(await Mediator.Send(new MockyQuery()));
        }
    }
}