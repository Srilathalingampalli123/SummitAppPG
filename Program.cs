using Microsoft.EntityFrameworkCore;
using Summit.Models.Models;
using Summit.Repositories.Interfaces;
using Summit.Repositories.Repositories;
using Summit.Repositories.Services.Implementations;
using Summit.Repositories.Services.Interfaces;
using SummitAppDemo.ActionFilters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DbContext, PgsummitContext>();
builder.Services.AddDbContext<PgsummitContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<ICustomerFNARepository, CustomerFNARepository>();
builder.Services.AddTransient<ValidationBodyActionFilter>();
builder.Services.AddTransient<ICustomerFNAInfoService, CustomerFNAInfoService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
