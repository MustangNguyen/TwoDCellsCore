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
    public static class NodeProcessEndpoints
    {
        public static void MapNodeProcessEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/NodeProcess").WithTags(nameof(NodeProcess));

            group.MapGet("/", async (TwoDCellsDbContext db) =>
            {
                return await db.NodeProcesses.ToListAsync();
            })
            .WithName("GetAllNodeProcesses")
            .WithOpenApi();

            group.MapGet("/{id}", async Task<Results<Ok<NodeProcess>, NotFound>> (string userid, TwoDCellsDbContext db) =>
            {
                return await db.NodeProcesses.AsNoTracking()
                    .FirstOrDefaultAsync(model => model.UserId == userid)
                    is NodeProcess model
                        ? TypedResults.Ok(model)
                        : TypedResults.NotFound();
            })
            .WithName("GetNodeProcessById")
            .WithOpenApi();

            group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (string userid, NodeProcess nodeProcess, TwoDCellsDbContext db) =>
            {
                var affected = await db.NodeProcesses
                    .Where(model => model.UserId == userid)
                    .ExecuteUpdateAsync(setters => setters
                      .SetProperty(m => m.UserId, nodeProcess.UserId)
                      .SetProperty(m => m.NodeId, nodeProcess.NodeId)
                      .SetProperty(m => m.IsNodeFinish, nodeProcess.IsNodeFinish)
                      .SetProperty(m => m.NodeScore, nodeProcess.NodeScore)
                      );
                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("UpdateNodeProcess")
            .WithOpenApi();

            group.MapPost("/", async (NodeProcess nodeProcess, TwoDCellsDbContext db) =>
            {
                db.NodeProcesses.Add(nodeProcess);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/api/NodeProcess/{nodeProcess.UserId}", nodeProcess);
            })
            .WithName("CreateNodeProcess")
            .WithOpenApi();
        }
    }
}
