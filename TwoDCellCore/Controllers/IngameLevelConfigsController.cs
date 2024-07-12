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
    public class IngameLevelConfigsController : ControllerBase
    {
        private readonly TwoDCellsDbContext _context;

        public IngameLevelConfigsController(TwoDCellsDbContext context)
        {
            _context = context;
        }

        // GET: api/IngameLevelConfigs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngameLevelConfig>>> GetIngameLevelConfig()
        {
            return await _context.IngameLevelConfig.ToListAsync();
        }

        // GET: api/IngameLevelConfigs/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<IngameLevelConfig>> GetIngameLevelConfig(int id)
        //{
        //    var ingameLevelConfig = await _context.IngameLevelConfig.FindAsync(id);

        //    if (ingameLevelConfig == null)
        //    {
        //        return NotFound();
        //    }

        //    return ingameLevelConfig;
        //}

        //// PUT: api/IngameLevelConfigs/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutIngameLevelConfig(int id, IngameLevelConfig ingameLevelConfig)
        //{
        //    if (id != ingameLevelConfig.inGameLv)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(ingameLevelConfig).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!IngameLevelConfigExists(id))
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

        //// POST: api/IngameLevelConfigs
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<IngameLevelConfig>> PostIngameLevelConfig(IngameLevelConfig ingameLevelConfig)
        //{
        //    _context.IngameLevelConfig.Add(ingameLevelConfig);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetIngameLevelConfig", new { id = ingameLevelConfig.inGameLv }, ingameLevelConfig);
        //}

        //// DELETE: api/IngameLevelConfigs/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteIngameLevelConfig(int id)
        //{
        //    var ingameLevelConfig = await _context.IngameLevelConfig.FindAsync(id);
        //    if (ingameLevelConfig == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.IngameLevelConfig.Remove(ingameLevelConfig);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool IngameLevelConfigExists(int id)
        {
            return _context.IngameLevelConfig.Any(e => e.inGameLv == id);
        }
    }
}
