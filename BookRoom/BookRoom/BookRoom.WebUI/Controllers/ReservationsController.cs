using BookRoom.Application.Reservations.Commands.AddReservation;
using BookRoom.Application.Reservations.Commands.DeleteReservation;
using BookRoom.Application.Reservations.Commands.UpdateReservation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BookRoom.WebUI.Controllers
{
    [Route("api/")]
    public class ReservationsController : BaseController
    {
        [HttpPost("Room/{id}/reservations")]
        [Description("Add new reservation to given room")]
        public async Task<ActionResult<string>> AddReservation([FromRoute] string id, [FromBody] AddReservationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("reservations/{id}")]
        [Description("Update reservation details")]
        public async Task<IActionResult> UpdateReservation([FromRoute] string id, [FromBody] UpdateReservationCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("reservations/{id}")]
        [Description("Delete reservation")]
        public async Task<IActionResult> DeleteReservation([FromRoute] string id)
        {
            await Mediator.Send(new DeleteReservationCommand { ReservationId = id });

            return NoContent();
        }
    }
}
