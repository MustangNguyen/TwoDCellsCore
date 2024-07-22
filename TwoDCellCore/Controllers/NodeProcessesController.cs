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

            group.MapPost("/", async (NodeProcess nodeProcess, TwoDCellsDbContext db) =>
            {
                NodeProcess selectedNode = await db.NodeProcesses.Where(x => x.UserId == nodeProcess.UserId && x.NodeId == nodeProcess.NodeId).FirstOrDefaultAsync();
                if(selectedNode != null && selectedNode.NodeScore > nodeProcess.NodeScore)
                {
                    return TypedResults.Ok();
                }
                var affected = await db.NodeProcesses
                    .Where(model => model.UserId == nodeProcess.UserId && model.NodeId == nodeProcess.NodeId)
                    .ExecuteUpdateAsync(setters => setters
                      .SetProperty(m => m.UserId, nodeProcess.UserId)
                      .SetProperty(m => m.NodeId, nodeProcess.NodeId)
                      .SetProperty(m => m.IsNodeFinish, nodeProcess.IsNodeFinish)
                      .SetProperty(m => m.NodeScore, nodeProcess.NodeScore)
                      );
                if (affected != 1)
                {
                    db.NodeProcesses.Add(nodeProcess);
                    await db.SaveChangesAsync();
                }
                //return TypedResults.Created($"/api/NodeProcess/{nodeProcess.UserId}", nodeProcess);
                return TypedResults.Ok();
            })
            .WithName("CreateNodeProcess")
            .RequireAuthorization()
            .WithOpenApi();
        }
    }
}
