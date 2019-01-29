using BookRoom.Application.Rooms.Commands.CreateRoom;
using BookRoom.Application.Rooms.Commands.DeleteRoom;
using BookRoom.Application.Rooms.Commands.UpdateRoom;
using BookRoom.Application.Rooms.Queries.GetRoomCalendar;
using BookRoom.Application.Rooms.Queries.GetRoomDetails;
using BookRoom.Application.Rooms.Queries.GetRooms;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Threading.Tasks;

namespace BookRoom.WebUI.Controllers
{
    public class RoomsController : BaseController
    {
        [HttpGet]
        [Description("Get all rooms")]
        public async Task<ActionResult<RoomsListViewModel>> GetRooms()
        {
            return Ok(await Mediator.Send(new GetRoomsQuery()));
        }

        [HttpGet("{id}")]
        [Description("Get details of one room")]
        public async Task<ActionResult<RoomDetailsViewModel>> GetRoomDetails([FromRoute] string id)
        {
            return Ok(await Mediator.Send(new GetRoomDetailsQuery { RoomId = id }));
        }

        [HttpGet("{id}/reservations")]
        [Description("Get all reservations for this room")]
        public async Task<IActionResult> GetRoomCalendar([FromRoute] string id)
        {
            return Ok(await Mediator.Send(new GetRoomCalendarQuery { RoomId = id }));
        }

        [HttpPost]
        [Description("Create new room")]
        public async Task<ActionResult<string>> CreateRoom([FromBody] CreateRoomCommand command)
        {
            var roomId = await Mediator.Send(command);

            return Ok(roomId);
        }

        [HttpPut("{id}")]
        [Description("Update room details")]
        public async Task<IActionResult> UpdateRoom([FromRoute] string id, [FromBody] UpdateRoomCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Description("Delete room")]
        public async Task<IActionResult> DeleteRoom([FromRoute] string id)
        {
            await Mediator.Send(new DeleteRoomCommand { Id = id });

            return NoContent();
        }
    }
}
