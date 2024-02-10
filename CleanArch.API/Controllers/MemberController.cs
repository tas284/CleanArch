using CleanArch.API.Models;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MemberController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetMembers()
        {
            var members = _unitOfWork.MemberRepository.GetMembers();

            return Ok(members);
        }

        [HttpPost]
        public async Task<IActionResult> AddMember(MemberInputModel memberInput)
        {
            var member = new Member(memberInput.FirstName, memberInput.LastName, memberInput.Gender);
            await _unitOfWork.MemberRepository.AddMember(member);

            return Ok(member);
        }
    }
}
