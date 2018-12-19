using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Task_1_Extra.Application.FizzBuzzs.Queries;

namespace Task_1_Extra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FizzBuzzController : BaseController
    {
        // GET api/fizz/5
        [HttpGet("{number}")]
        public async Task<ActionResult<string>> Get(int number)
        {
            //return Ok(new FizzBuzzQuery { Number = number });
            return Ok(await Mediator.Send(new FizzBuzzQuery { Number = number }));
        }
    }
}
