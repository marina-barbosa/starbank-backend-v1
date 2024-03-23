using StarBank.Domain;
using StarBank.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConectionString");

builder.Services.AddDbContext<StarDbContext>(options =>
{
    options.UseSqlite("DefaultConectionString");
});

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<StarDbContext>().AddDefaultTokenProviders();



    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.MapControllers();


    app.Run();
