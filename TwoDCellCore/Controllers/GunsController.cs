using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwoDCellCore.Models;

namespace TwoDCellCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GunsController : ControllerBase
    {
        private readonly TwoDCellsDbContext _context;

        public GunsController(TwoDCellsDbContext context)
        {
            _context = context;
        }

        // GET: api/Guns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gun>>> GetGuns()
        {
            List<Gun> guns = await _context.Guns.ToListAsync();
            foreach(var gun in guns)
            {
                gun.GunId = gun.GunId.Trim();
                gun.GunName = gun.GunName.Trim();
            }
            return guns;
        }

        //// GET: api/Guns/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Gun>> GetGun(string id)
        //{
        //    var gun = await _context.Guns.FindAsync(id);

        //    if (gun == null)
        //    {
        //        return NotFound();
        //    }

        //    return gun;
        //}

        //// PUT: api/Guns/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutGun(string id, Gun gun)
        //{
        //    if (id != gun.GunId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(gun).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GunExists(id))
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

        //// POST: api/Guns
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Gun>> PostGun(Gun gun)
        //{
        //    _context.Guns.Add(gun);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (GunExists(gun.GunId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetGun", new { id = gun.GunId }, gun);
        //}

        //// DELETE: api/Guns/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteGun(string id)
        //{
        //    var gun = await _context.Guns.FindAsync(id);
        //    if (gun == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Guns.Remove(gun);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool GunExists(string id)
        {
            return _context.Guns.Any(e => e.GunId == id);
        }
    }
}
