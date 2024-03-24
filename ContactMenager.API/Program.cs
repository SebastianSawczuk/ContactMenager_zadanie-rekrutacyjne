
using ContactMenager.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ContactMenagerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ContactMenagerContext") ?? throw new InvalidOperationException("Connection string 'ContactMenagerContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentityCore<ApplicationUser>()
    .AddEntityFrameworkStores<ContactMenagerContext>()
    .AddApiEndpoints();

builder.Services.AddAuthorizationBuilder();
builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapIdentityApi<ApplicationUser>();

app.MapControllers();

app.Run();
