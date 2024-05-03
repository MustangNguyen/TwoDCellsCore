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
    public class MutationAbilitiesController : ControllerBase
    {
        private readonly TwoDCellsDbContext _context;

        public MutationAbilitiesController(TwoDCellsDbContext context)
        {
            _context = context;
        }

        // GET: api/MutationAbilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MutationAbility>>> GetMutationAbilities()
        {
            List<MutationAbility> abilities = new List<MutationAbility>();
            foreach(var item in _context.MutationAbilities)
            {
                item.AbilityId = item.AbilityId.Trim();
                item.AbilityName = item.AbilityName.Trim();
                abilities.Add(item);
            }
            return await _context.MutationAbilities.ToListAsync();
        }

        //// GET: api/MutationAbilities/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<MutationAbility>> GetMutationAbility(string id)
        //{
        //    var mutationAbility = await _context.MutationAbilities.FindAsync(id);

        //    if (mutationAbility == null)
        //    {
        //        return NotFound();
        //    }

        //    return mutationAbility;
        //}

        //// PUT: api/MutationAbilities/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutMutationAbility(string id, MutationAbility mutationAbility)
        //{
        //    if (id != mutationAbility.AbilityId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(mutationAbility).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MutationAbilityExists(id))
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

        //// POST: api/MutationAbilities
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<MutationAbility>> PostMutationAbility(MutationAbility mutationAbility)
        //{
        //    _context.MutationAbilities.Add(mutationAbility);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (MutationAbilityExists(mutationAbility.AbilityId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetMutationAbility", new { id = mutationAbility.AbilityId }, mutationAbility);
        //}

        //// DELETE: api/MutationAbilities/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteMutationAbility(string id)
        //{
        //    var mutationAbility = await _context.MutationAbilities.FindAsync(id);
        //    if (mutationAbility == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.MutationAbilities.Remove(mutationAbility);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool MutationAbilityExists(string id)
        //{
        //    return _context.MutationAbilities.Any(e => e.AbilityId == id);
        //}
    }
}
