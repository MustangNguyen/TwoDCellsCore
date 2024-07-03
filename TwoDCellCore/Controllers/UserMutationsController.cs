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
    public class UserMutationsController : ControllerBase
    {
        private readonly TwoDCellsDbContext _context;

        public UserMutationsController(TwoDCellsDbContext context)
        {
            _context = context;
        }

        //// GET: api/UserMutations
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<UserMutation>>> GetUserMutations()
        //{
        //    return await _context.UserMutations.ToListAsync();
        //}

        //// GET: api/UserMutations/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<UserMutation>> GetUserMutation(string id)
        //{
        //    var userMutation = await _context.UserMutations.FindAsync(id);

        //    if (userMutation == null)
        //    {
        //        return NotFound();
        //    }

        //    return userMutation;
        //}

        //// PUT: api/UserMutations/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUserMutation(string id, UserMutation userMutation)
        //{
        //    if (id != userMutation.OwnershipId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(userMutation).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserMutationExists(id))
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

        //// POST: api/UserMutations
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<UserMutation>> PostUserMutation(UserMutation userMutation)
        //{
        //    _context.UserMutations.Add(userMutation);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (UserMutationExists(userMutation.OwnershipId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetUserMutation", new { id = userMutation.OwnershipId }, userMutation);
        //}

        //// DELETE: api/UserMutations/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUserMutation(string id)
        //{
        //    var userMutation = await _context.UserMutations.FindAsync(id);
        //    if (userMutation == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.UserMutations.Remove(userMutation);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool UserMutationExists(string id)
        {
            return _context.UserMutations.Any(e => e.OwnershipId == id);
        }
    }


public static class UserMutationEndpoints
{
        [Authorize]
        public static void MapUserMutationEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/UserMutation").WithTags(nameof(UserMutation)).RequireAuthorization();
            group.MapGet("/", async (TwoDCellsDbContext db) =>
            {
                return await db.UserMutations.ToListAsync();
            })
            .WithName("GetAllUserMutations")
            .WithOpenApi();

            group.MapGet("/getUserMutationList/{UserID}", async (string UserID, TwoDCellsDbContext db) =>
            {
                var listUserMutation = await db.UserMutations.Where(u => u.UserId == UserID).ToListAsync();
                foreach(var item in listUserMutation)
                {
                    item.MutationId = item.MutationId.Trim();
                }
                return Results.Ok(listUserMutation);
            })
            .WithName("GetUserMutationList")
            .WithOpenApi();

            //group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (string ownershipid, UserMutation userMutation, TwoDCellsDbContext db) =>
            //{
            //    var affected = await db.UserMutations
            //        .Where(model => model.OwnershipId == ownershipid)
            //        .ExecuteUpdateAsync(setters => setters
            //          .SetProperty(m => m.OwnershipId, userMutation.OwnershipId)
            //          .SetProperty(m => m.UserId, userMutation.UserId)
            //          .SetProperty(m => m.MutationId, userMutation.MutationId)
            //          .SetProperty(m => m.MutationLv, userMutation.MutationLv)
            //          .SetProperty(m => m.MutationXp, userMutation.MutationXp)
            //          );
            //    return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            //})
            //    .WithName("UpdateUserMutation")
            //    .WithOpenApi();

            group.MapPost("/AddNewMutation/", async (NewUserMutation newUserMutation, TwoDCellsDbContext db) =>
            {
                UserMutation userMutation = new();
                userMutation.OwnershipId = newUserMutation.UserId + newUserMutation.MutationId;
                userMutation.MutationId = newUserMutation.MutationId;
                userMutation.UserId = newUserMutation.UserId;
                userMutation.MutationLv = 0;
                userMutation.MutationXp = 0;
                var existingUserMutation = await db.UserMutations.FirstOrDefaultAsync(u => u.UserId == userMutation.UserId && u.MutationId == userMutation.MutationId);
                int count = 0;

                while (existingUserMutation != null)
                {
                    count++;
                    userMutation.OwnershipId = userMutation.UserId + userMutation.MutationId + count;
                    existingUserMutation = await db.UserMutations.FirstOrDefaultAsync(u => u.OwnershipId == userMutation.OwnershipId);
                }
                db.UserMutations.Add(userMutation);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/api/UserMutation/{userMutation.OwnershipId}", userMutation);
            })
            .WithName("CreateUserMutation")
            .WithOpenApi();

            group.MapPost("/UpgradeMutation/", async (UpgradeUserMutation upgradeUserMutation, TwoDCellsDbContext db) =>
            {
                UserMutation userMutation = new();
                userMutation = await db.UserMutations.Where(u => u.OwnershipId == upgradeUserMutation.OwnerShipId).FirstAsync();
                userMutation.MutationLv = upgradeUserMutation.Lv;
                userMutation.MutationXp = upgradeUserMutation.Xp;
                var affected = await db.UserMutations
                    .Where(model => model.OwnershipId == upgradeUserMutation.OwnerShipId)
                    .ExecuteUpdateAsync(setters => setters
                      .SetProperty(m => m.OwnershipId, userMutation.OwnershipId)
                      .SetProperty(m => m.UserId, userMutation.UserId)
                      .SetProperty(m => m.MutationId, userMutation.MutationId)
                      .SetProperty(m => m.MutationLv, upgradeUserMutation.Lv)
                      .SetProperty(m => m.MutationXp, upgradeUserMutation.Xp)
                      );
                await db.SaveChangesAsync();
                return Results.Ok(userMutation);
            })
            .WithName("UpgradeUserMutation")
            .WithOpenApi();
        }
}}
public class NewUserMutation
{
    public string UserId { get; set; } = null!;
    public string MutationId { get; set; } = null!;
}
public class UpgradeUserMutation
{
    public string OwnerShipId { get; set; } = null!;
    public int Lv { get; set; }
    public int Xp { get; set; }
}