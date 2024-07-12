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
                foreach (var item in listUserGun)
                {
                    item.GunId = item.GunId.Trim();
                }
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
                return affected == 1 ? Results.Ok(userGun) : Results.NotFound();
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
    public string UserId { get; set; } = null!;
    public string GunId { get; set; } = null!;
}
public class UpgradeUserGun
{
    public string OwnerShipId { get; set; } = null!;
    public int Lv { get; set; }
    public int Xp { get; set; }
}