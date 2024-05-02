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
    public class MutationsController : ControllerBase
    {
        private readonly TwoDCellsDbContext _context;

        public MutationsController(TwoDCellsDbContext context)
        {

            _context = context;
        }

        // GET: api/Mutations
        [HttpGet]
        public IEnumerable<Mutation> Getmutations()
        {
            List<Mutation> ListTestTable1 =  _context.Mutations
                                            .Include(m => m.MutationAbilities)
                                            .ToList();

            List<MutationAbility> listAbilities;
            foreach (var item in ListTestTable1)
            {
                item.MutationId = item.MutationId.Trim();
                item.MutationName = item.MutationName.Trim();
                item.CellProtection = item.CellProtection.Trim();
                item.FactionId = item.FactionId.Trim();
                item.ShieldType = item.ShieldType.Trim();
                listAbilities = new List<MutationAbility>(item.MutationAbilities.ToList());
                foreach (var ability in listAbilities)
                {
                    ability.AbilityId = ability.AbilityId.Trim();
                    ability.AbilityName = ability.AbilityName.Trim();
                }
            }
            return ListTestTable1.ToList();
        }

        // GET: api/Mutations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mutation>> GetMutation(string id)
        {
            var mutation = await _context.Mutations.FindAsync(id);

            if (mutation == null)
            {
                return NotFound();
            }

            return mutation;
        }

        // PUT: api/Mutations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutMutation(string id, Mutation mutation)
        //{
        //    if (id != mutation.MutationId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(mutation).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MutationExists(id))
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

        // POST: api/Mutations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mutation>> PostMutation(Mutation mutation)
        {
            _context.Mutations.Add(mutation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MutationExists(mutation.MutationId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMutation", new { id = mutation.MutationId }, mutation);
        }

        // DELETE: api/Mutations/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteMutation(string id)
        //{
        //    var mutation = await _context.Mutations.FindAsync(id);
        //    if (mutation == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Mutations.Remove(mutation);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool MutationExists(string id)
        {
            return _context.Mutations.Any(e => e.MutationId == id);
        }
    }
}
