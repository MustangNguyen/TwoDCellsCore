using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwoDCellCore.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;

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

        //// GET: api/UserGuns
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<UserGun>>> GetUserGuns()
        //{
        //    return await _context.UserGuns.ToListAsync();
        //}

        //// GET: api/UserGuns/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<UserGun>> GetUserGun(string id)
        //{
        //    var userGun = await _context.UserGuns.FindAsync(id);

        //    if (userGun == null)
        //    {
        //        return NotFound();
        //    }

        //    return userGun;
        //}

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

    public static class UserGunEndpoints
    {
        [Authorize]
        public static void MapUserGunEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/UserGun").WithTags(nameof(UserGun)).RequireAuthorization();
            group.MapGet("/", async (TwoDCellsDbContext db) =>
            {
                return await db.UserGuns.ToListAsync();
            })
            .WithName("GetAllUserGuns")
            .WithOpenApi();

            group.MapGet("/getUserGunList/{UserID}", async (string UserID, TwoDCellsDbContext db) =>
            {
                var listUserGun = await db.UserGuns.Where(u => u.UserId == UserID).ToListAsync();
                return Results.Ok(listUserGun);
            })
            .WithName("GetUserGunList")
            .WithOpenApi();

            //group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (string ownershipid, UserGun userGun, TwoDCellsDbContext db) =>
            //{
            //    var affected = await db.UserGuns
            //        .Where(model => model.OwnershipId == ownershipid)
            //        .ExecuteUpdateAsync(setters => setters
            //          .SetProperty(m => m.OwnershipId, userGun.OwnershipId)
            //          .SetProperty(m => m.UserId, userGun.UserId)
            //          .SetProperty(m => m.GunId, userGun.GunId)
            //          .SetProperty(m => m.GunLv, userGun.GunLv)
            //          .SetProperty(m => m.GunXp, userGun.GunXp)
            //          );
            //    return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            //})
            //    .WithName("UpdateUserGun")
            //    .WithOpenApi();

            group.MapPost("/AddNewGun/", async (NewUserGun newUserGun, TwoDCellsDbContext db) =>
            {
                UserGun userGun = new();
                userGun.OwnershipId = newUserGun.UserId + newUserGun.GunId;
                userGun.GunId = newUserGun.GunId;
                userGun.UserId = newUserGun.UserId;
                userGun.GunLv = 0;
                userGun.GunXp = 0;
                var existingUserGun = await db.UserGuns.FirstOrDefaultAsync(u => u.UserId == userGun.UserId && u.GunId == userGun.GunId);
                int count = 0;

                while (existingUserGun != null)
                {
                    count++;
                    userGun.OwnershipId = userGun.UserId + userGun.GunId + count;
                    existingUserGun = await db.UserGuns.FirstOrDefaultAsync(u => u.OwnershipId == userGun.OwnershipId);
                }
                db.UserGuns.Add(userGun);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/api/UserGun/{userGun.OwnershipId}", userGun);
            })
            .WithName("CreateUserGun")
            .WithOpenApi();

            group.MapPost("/UpgradeGun/", async (UpgradeUserGun upgradeUserGun, TwoDCellsDbContext db) =>
            {
                UserGun userGun = new();
                userGun = await db.UserGuns.Where(u => u.OwnershipId == upgradeUserGun.OwnerShipId).FirstAsync();
                userGun.GunLv = upgradeUserGun.Lv;
                userGun.GunXp = upgradeUserGun.Xp;
                var affected = await db.UserGuns
                    .Where(model => model.OwnershipId == upgradeUserGun.OwnerShipId)
                    .ExecuteUpdateAsync(setters => setters
                      .SetProperty(m => m.OwnershipId, userGun.OwnershipId)
                      .SetProperty(m => m.UserId, userGun.UserId)
                      .SetProperty(m => m.GunId, userGun.GunId)
                      .SetProperty(m => m.GunLv, upgradeUserGun.Lv)
                      .SetProperty(m => m.GunXp, upgradeUserGun.Xp)
                      );
                await db.SaveChangesAsync();
                return Results.Ok(userGun);
            })
            .WithName("UpgradeUserGun")
            .WithOpenApi();

            //group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (string ownershipid, TwoDCellsDbContext db) =>
            //{
            //    var affected = await db.UserGuns
            //        .Where(model => model.OwnershipId == ownershipid)
            //    .ExecuteDeleteAsync();
            //    return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            //})
            //.WithName("DeleteUserGun")
            //.WithOpenApi();
        }
    }
}
public class NewUserGun
{
    public string UserId { get; set; }
    public string GunId { get; set; }
}
public class UpgradeUserGun
{
    public string OwnerShipId { get; set; }
    public int Lv { get; set; }
    public int Xp { get; set; }
}