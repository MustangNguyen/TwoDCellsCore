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
    public class PlanetsController : ControllerBase
    {
        private readonly TwoDCellsDbContext _context;

        public PlanetsController(TwoDCellsDbContext context)
        {
            _context = context;
        }

        // GET: api/Planets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Planet>>> GetPlanets()
        {
            List<Planet> listPlanets = new List<Planet>(_context.Planets.ToList());
            foreach(Planet planet in listPlanets)
            {
                var nodes = await _context.PlanetNodes
                              .Where(n => n.PlanetId == planet.PlanetId)
                              .ToListAsync();
                planet.PlanetNodes = nodes;
            }
            return listPlanets;
        }
    }
}
