using CleanArch.API.Models;
using CleanArch.Application.Commands;
using CleanArch.Application.Members.Commands;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public MemberController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        [HttpGet("")]
        public IActionResult GetMembers()
        {
            var members = _unitOfWork.MemberRepository.GetMembers();

            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemberById(int id)
        {
            try
            {
                var member = await _unitOfWork.MemberRepository.GetMemberById(id);

                return Ok(member);
            }
            catch(Exception ex)
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
            command.Id = id;
            var updatedMember = await _mediator.Send(command);

            return updatedMember == null ? NotFound("Member not found") : Ok(updatedMember);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var command = new DeleteMemberCommand { Id = id };

            var deletedMember = await _mediator.Send(command);

            return deletedMember == null ? NotFound("Member not found.") : Ok(deletedMember);
        }
    }
}
