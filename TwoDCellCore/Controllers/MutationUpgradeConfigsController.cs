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
    public class MutationUpgradeConfigsController : ControllerBase
    {
        private readonly TwoDCellsDbContext _context;

        public MutationUpgradeConfigsController(TwoDCellsDbContext context)
        {
            _context = context;
        }

        // GET: api/MutationUpgradeConfigs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MutationUpgradeConfig>>> GetMutationUpgradeConfigs()
        {
            return await _context.MutationUpgradeConfigs.ToListAsync();
        }

        //// GET: api/MutationUpgradeConfigs/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<MutationUpgradeConfig>> GetMutationUpgradeConfig(int id)
        //{
        //    var mutationUpgradeConfig = await _context.MutationUpgradeConfigs.FindAsync(id);

        //    if (mutationUpgradeConfig == null)
        //    {
        //        return NotFound();
        //    }

        //    return mutationUpgradeConfig;
        //}

        //// PUT: api/MutationUpgradeConfigs/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutMutationUpgradeConfig(int id, MutationUpgradeConfig mutationUpgradeConfig)
        //{
        //    if (id != mutationUpgradeConfig.MutationLv)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(mutationUpgradeConfig).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MutationUpgradeConfigExists(id))
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

        //// POST: api/MutationUpgradeConfigs
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<MutationUpgradeConfig>> PostMutationUpgradeConfig(MutationUpgradeConfig mutationUpgradeConfig)
        //{
        //    _context.MutationUpgradeConfigs.Add(mutationUpgradeConfig);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetMutationUpgradeConfig", new { id = mutationUpgradeConfig.MutationLv }, mutationUpgradeConfig);
        //}

        //// DELETE: api/MutationUpgradeConfigs/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteMutationUpgradeConfig(int id)
        //{
        //    var mutationUpgradeConfig = await _context.MutationUpgradeConfigs.FindAsync(id);
        //    if (mutationUpgradeConfig == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.MutationUpgradeConfigs.Remove(mutationUpgradeConfig);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool MutationUpgradeConfigExists(int id)
        //{
        //    return _context.MutationUpgradeConfigs.Any(e => e.MutationLv == id);
        //}
    }
}
