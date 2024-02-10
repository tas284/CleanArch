using CleanArch.API.Models;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [Route("api/members")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MemberController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("all")]
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

        [HttpPost("add")]
        public async Task<IActionResult> AddMember(MemberInputModel model)
        {
            var member = new Member(model.FirstName, model.LastName, model.Gender, model.Email, model.BirthDate, model.Active);
            await _unitOfWork.MemberRepository.AddMember(member);
            await _unitOfWork.CommitAsync();

            return Ok(member);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateMember(int id, MemberInputModel model)
        {
            try
            {
                var member = await _unitOfWork.MemberRepository.GetMemberById(id);

                if (member != null)
                {
                    member.FirstName = model.FirstName;
                    member.LastName = model.LastName;
                    member.Gender = model.Gender;
                    member.Email = model.Email;
                    member.BirthDate = model.BirthDate;
                    member.Active = model.Active;

                    _unitOfWork.MemberRepository.UpdateMember(member);
                    await _unitOfWork.CommitAsync();
                    return Ok(member);
                }

                return NotFound("Member not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            try
            {
                var existMember = _unitOfWork.MemberRepository.GetMemberById(id);

                if (existMember != null)
                {
                    var memberDelete = await _unitOfWork.MemberRepository.DeleteMember(id);
                    await _unitOfWork.CommitAsync();

                    return NoContent();
                }

                return NotFound("Member not found: {0}" + id);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
