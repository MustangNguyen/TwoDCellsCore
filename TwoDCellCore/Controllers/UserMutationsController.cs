using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwoDCellCore.Models;

namespace TwoDCellCore.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserMutationsController : ControllerBase
    {
        private readonly TwoDCellsDbContext _context;

        public UserMutationsController(TwoDCellsDbContext context)
        {
            _context = context;
        }

        // GET: api/UserMutations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserMutation>>> GetUserMutations()
        {
            return await _context.UserMutations.ToListAsync();
        }

        // GET: api/UserMutations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserMutation>> GetUserMutation(string id)
        {
            var userMutation = await _context.UserMutations.FindAsync(id);

            if (userMutation == null)
            {
                return NotFound();
            }

            return userMutation;
        }

        //// PUT: api/UserMutations/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUserMutation(string id, UserMutation userMutation)
        //{
        //    if (id != userMutation.OwnershipId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(userMutation).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserMutationExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/UserMutations
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<UserMutation>> PostUserMutation(UserMutation userMutation)
        //{
        //    _context.UserMutations.Add(userMutation);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (UserMutationExists(userMutation.OwnershipId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetUserMutation", new { id = userMutation.OwnershipId }, userMutation);
        //}

        //// DELETE: api/UserMutations/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUserMutation(string id)
        //{
        //    var userMutation = await _context.UserMutations.FindAsync(id);
        //    if (userMutation == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.UserMutations.Remove(userMutation);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool UserMutationExists(string id)
        {
            return _context.UserMutations.Any(e => e.OwnershipId == id);
        }
    }
}
