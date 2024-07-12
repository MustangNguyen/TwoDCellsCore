using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwoDCellCore.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;

namespace TwoDCellCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserEquipmentsController : ControllerBase
    {
        private readonly TwoDCellsDbContext _context;

        public UserEquipmentsController(TwoDCellsDbContext context)
        {
            _context = context;
        }

        

    }


public static class UserEquipmentEndpoints
{
	public static void MapUserEquipmentEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/UserEquipment").WithTags(nameof(UserEquipment));

        group.MapGet("/GetAllUserEquipments/", async (TwoDCellsDbContext db) =>
        {
            return await db.UserEquipment.ToListAsync();
        })
        .WithName("GetAllUserEquipments")
        .WithOpenApi();

        group.MapGet("/GetUserEquipmentById/{id}", async Task<Results<Ok<List<UserEquipment>>, NotFound>> (string userid, TwoDCellsDbContext db) =>
        {
            var results = await db.UserEquipment.AsNoTracking()
                .Where(model => model.UserId == userid)
                .ToListAsync();
            return results.Any()
                ? TypedResults.Ok(results)
                : TypedResults.NotFound();
        })
        .WithName("GetUserEquipmentById")
        .RequireAuthorization()
        .WithOpenApi();


            group.MapPost("/CreateUserEquipment/", async (NewUserEquipment newUserEquipment, TwoDCellsDbContext db) =>
        {
            UserEquipment userEquipment = new();
            int count = 0;
            userEquipment.UserEquipmentId = userEquipment.UserId + count;
            userEquipment.UserId = newUserEquipment.UserId;
            var existingUserEquipment = await db.UserEquipment.FirstOrDefaultAsync(u => u.UserId == newUserEquipment.UserId);
            while (existingUserEquipment != null)
            {
                count++;
                userEquipment.UserEquipmentId = userEquipment.UserId + count;
                existingUserEquipment = await db.UserEquipment.FirstOrDefaultAsync(u => u.UserEquipmentId == userEquipment.UserEquipmentId);
            }
            db.UserEquipment.Add(userEquipment);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/UserEquipment/{userEquipment.UserId}",userEquipment);
        })
        .WithName("CreateUserEquipment")
        .RequireAuthorization()
        .WithOpenApi();

        group.MapPost("/UpdateUserEquipment/", async (UpdateUserEquipment updateUserEquipment, TwoDCellsDbContext db) =>
        {
            if(updateUserEquipment.GunOwnershipId1 == updateUserEquipment.GunOwnershipId2)
            {
                return Results.BadRequest("Update player's equipment failed");
            }
            var affected = await db.UserEquipment
                .Where(model => model.UserEquipmentId == updateUserEquipment.UserEquipmentId)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.UserEquipmentId, updateUserEquipment.UserEquipmentId)
                    .SetProperty(m => m.MutationOwnershipId, updateUserEquipment.MutationOwnershipId)
                    .SetProperty(m => m.GunOwnershipId1, updateUserEquipment.GunOwnershipId1)
                    .SetProperty(m => m.GunOwnershipId2, updateUserEquipment.GunOwnershipId2)
                    );
            return affected == 1 ? Results.Ok(updateUserEquipment) : Results.NotFound();
        })
        .WithName("UpdateUserEquipment")
        .RequireAuthorization()
        .WithOpenApi();
        }
}}
public class NewUserEquipment
{
    public string UserId { get; set; } = null!;
}
public class UpdateUserEquipment
{
    public string UserEquipmentId { get; set; } = null!;
    public string? MutationOwnershipId { get; set; }
    public string? GunOwnershipId1 { get; set; }
    public string? GunOwnershipId2 { get; set; }
}