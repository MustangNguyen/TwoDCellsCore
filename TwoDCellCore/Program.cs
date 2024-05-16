using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TwoDCellCore.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<TwoDCellsDbContext>();
builder.Services.AddDbContext<TwoDCellsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TwoDCellDatabaseLocal")));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.MapGroup("/identity").MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
