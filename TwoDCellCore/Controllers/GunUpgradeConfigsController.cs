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
    public class GunUpgradeConfigsController : ControllerBase
    {
        private readonly TwoDCellsDbContext _context;

        public GunUpgradeConfigsController(TwoDCellsDbContext context)
        {
            _context = context;
        }

        // GET: api/GunUpgradeConfigs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GunUpgradeConfig>>> GetGunUpgradeConfigs()
        {
            return await _context.GunUpgradeConfigs.ToListAsync();
        }

        //// GET: api/GunUpgradeConfigs/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<GunUpgradeConfig>> GetGunUpgradeConfig(int id)
        //{
        //    var gunUpgradeConfig = await _context.GunUpgradeConfigs.FindAsync(id);

        //    if (gunUpgradeConfig == null)
        //    {
        //        return NotFound();
        //    }

        //    return gunUpgradeConfig;
        //}

        //// PUT: api/GunUpgradeConfigs/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutGunUpgradeConfig(int id, GunUpgradeConfig gunUpgradeConfig)
        //{
        //    if (id != gunUpgradeConfig.MutationLv)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(gunUpgradeConfig).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GunUpgradeConfigExists(id))
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

        //// POST: api/GunUpgradeConfigs
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<GunUpgradeConfig>> PostGunUpgradeConfig(GunUpgradeConfig gunUpgradeConfig)
        //{
        //    _context.GunUpgradeConfigs.Add(gunUpgradeConfig);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetGunUpgradeConfig", new { id = gunUpgradeConfig.MutationLv }, gunUpgradeConfig);
        //}

        //// DELETE: api/GunUpgradeConfigs/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteGunUpgradeConfig(int id)
        //{
        //    var gunUpgradeConfig = await _context.GunUpgradeConfigs.FindAsync(id);
        //    if (gunUpgradeConfig == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.GunUpgradeConfigs.Remove(gunUpgradeConfig);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool GunUpgradeConfigExists(int id)
        //{
        //    return _context.GunUpgradeConfigs.Any(e => e.MutationLv == id);
        //}
    }
}
