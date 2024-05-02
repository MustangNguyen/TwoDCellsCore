﻿using System;
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
    public class EnemyCellsController : ControllerBase
    {
        private readonly TwoDCellsDbContext _context;

        public EnemyCellsController(TwoDCellsDbContext context)
        {
            _context = context;
        }

        // GET: api/EnemyCells
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnemyCell>>> GetEnemyCells()
        {
            return await _context.EnemyCells.ToListAsync();
        }

        // GET: api/EnemyCells/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnemyCell>> GetEnemyCell(string id)
        {
            var enemyCell = await _context.EnemyCells.FindAsync(id);

            if (enemyCell == null)
            {
                return NotFound();
            }

            return enemyCell;
        }

        // PUT: api/EnemyCells/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnemyCell(string id, EnemyCell enemyCell)
        {
            if (id != enemyCell.EnemyId)
            {
                return BadRequest();
            }

            _context.Entry(enemyCell).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnemyCellExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EnemyCells
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EnemyCell>> PostEnemyCell(EnemyCell enemyCell)
        {
            _context.EnemyCells.Add(enemyCell);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EnemyCellExists(enemyCell.EnemyId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEnemyCell", new { id = enemyCell.EnemyId }, enemyCell);
        }

        // DELETE: api/EnemyCells/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnemyCell(string id)
        {
            var enemyCell = await _context.EnemyCells.FindAsync(id);
            if (enemyCell == null)
            {
                return NotFound();
            }

            _context.EnemyCells.Remove(enemyCell);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnemyCellExists(string id)
        {
            return _context.EnemyCells.Any(e => e.EnemyId == id);
        }
    }
}
