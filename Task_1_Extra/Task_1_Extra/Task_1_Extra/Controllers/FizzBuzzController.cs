using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Task_1_Extra.Application.FizzBuzzs.Queries;

namespace Task_1_Extra.Controllers
{
    /// <summary>
    /// This is a FizzBuzz controller.
    /// </summary>
    [ApiController]
    public class FizzBuzzController : BaseController
    {
        /// <summary>
        /// For multiples of three return "Fizz" instead of the number
        /// and for the multiples of five return "Buzz".
        /// For numbers which are multiples of both three and five return "FizzBuzz".
        /// </summary>
        /// <param name="number">Number to check</param>
        /// <returns>Fizz, Buzz, FizzBuzz or {number}</returns>
        [HttpGet("{number}")]
        [Produces("text/plain")]
        public async Task<ActionResult<string>> Get(int number)
        {
            return Ok(await Mediator.Send(new FizzBuzzQuery { Number = number }));
        }
    }
}
