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
    public class UserGunsController : ControllerBase
    {
        private readonly TwoDCellsDbContext _context;

        public UserGunsController(TwoDCellsDbContext context)
        {
            _context = context;
        }

        // GET: api/UserGuns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGun>>> GetUserGuns()
        {
            return await _context.UserGuns.ToListAsync();
        }

        // GET: api/UserGuns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserGun>> GetUserGun(string id)
        {
            var userGun = await _context.UserGuns.FindAsync(id);

            if (userGun == null)
            {
                return NotFound();
            }

            return userGun;
        }

        //// PUT: api/UserGuns/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUserGun(string id, UserGun userGun)
        //{
        //    if (id != userGun.OwnershipId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(userGun).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserGunExists(id))
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

        //// POST: api/UserGuns
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<UserGun>> PostUserGun(UserGun userGun)
        //{
        //    _context.UserGuns.Add(userGun);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (UserGunExists(userGun.OwnershipId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetUserGun", new { id = userGun.OwnershipId }, userGun);
        //}

        //// DELETE: api/UserGuns/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUserGun(string id)
        //{
        //    var userGun = await _context.UserGuns.FindAsync(id);
        //    if (userGun == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.UserGuns.Remove(userGun);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool UserGunExists(string id)
        {
            return _context.UserGuns.Any(e => e.OwnershipId == id);
        }
    }
}
