using CleanArch.Application.Commands;
using CleanArch.Application.Members.Commands;
using CleanArch.Application.Members.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MembersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetMembers()
        {
            var members = await _mediator.Send(new GetMembersQuery());

            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemberById(int id)
        {
            try
            {
                var query = new GetMemberByIdQuery { Id = id };
                var member = await _mediator.Send(query);

                return Ok(member);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember(CreateMemberCommand command)
        {
            var createdMember = await _mediator.Send(command);

            return Ok(createdMember);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(int id, UpdateMemberCommand command)
        {
            try
            {
                command.Id = id;
                var updatedMember = await _mediator.Send(command);

                return updatedMember == null ? NotFound("Member not found") : Ok(updatedMember);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            try
            {
                var command = new DeleteMemberCommand { Id = id };

                var deletedMember = await _mediator.Send(command);

                return deletedMember == null ? NotFound("Member not found.") : Ok(deletedMember);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
