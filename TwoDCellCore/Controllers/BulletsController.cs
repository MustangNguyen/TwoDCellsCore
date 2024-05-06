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
    public class BulletsController : ControllerBase
    {
        private readonly TwoDCellsDbContext _context;

        public BulletsController(TwoDCellsDbContext context)
        {
            _context = context;
        }

        // GET: api/Bullets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bullet>>> GetBullets()
        {
            List<Bullet> bullets = new List<Bullet>(_context.Bullets.ToList());
            foreach(var bullet in bullets)
            {
                bullet.BulletId = bullet.BulletId.Trim();
                bullet.BulletName = bullet.BulletName.Trim();
                bullet.BulletTypeId = bullet.BulletTypeId.Trim();
                bullet.Element = bullet.Element.Trim();
            }
            return bullets;
        }

        //// GET: api/Bullets/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Bullet>> GetBullet(string id)
        //{
        //    var bullet = await _context.Bullets.FindAsync(id);

        //    if (bullet == null)
        //    {
        //        return NotFound();
        //    }

        //    return bullet;
        //}

        //// PUT: api/Bullets/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutBullet(string id, Bullet bullet)
        //{
        //    if (id != bullet.BulletId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(bullet).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BulletExists(id))
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

        //// POST: api/Bullets
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Bullet>> PostBullet(Bullet bullet)
        //{
        //    _context.Bullets.Add(bullet);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (BulletExists(bullet.BulletId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetBullet", new { id = bullet.BulletId }, bullet);
        //}

        //// DELETE: api/Bullets/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteBullet(string id)
        //{
        //    var bullet = await _context.Bullets.FindAsync(id);
        //    if (bullet == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Bullets.Remove(bullet);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool BulletExists(string id)
        //{
        //    return _context.Bullets.Any(e => e.BulletId == id);
        //}
    }
}
