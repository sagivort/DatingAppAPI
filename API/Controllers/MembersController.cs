using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class MembersController(AppDbContext context) : BaseAPIController
    {
        [Authorize]
        [HttpGet] // api/members
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
            var res = await context.Users.ToListAsync();
            return Ok(res);
        }

        [HttpGet("{id}")] // api/members/3
        public async Task<ActionResult<AppUser>> GetMember(string id)
        {
            var res = await context.Users.FindAsync(id);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }
        
        [HttpGet("by-name/{displayName}")] // api/members/by-name/sagiv
        public ActionResult<AppUser> GetMemberByDisplayName(string displayName)
        {
            var res = context.Users.FirstOrDefault(u => u.DisplayName == displayName);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

    }
}
