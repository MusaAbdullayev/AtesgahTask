using Ecommerse.DAL.Context;
using Ecommerse.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Ecommerse.DAL;
using Ecommerse.BL;
using Ecommerse.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // 1. Token qutusu (Definition)
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Z?hm?t olmasa tokeni daxil edin."
    });

    // 2. T?hlük?sizlik t?l?bi (Requirement)
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.User.RequireUniqueEmail = true;
    opt.Password.RequireUppercase = true;

    opt.Password.RequireLowercase = true;
    opt.Password.RequiredLength = 8;
    opt.Password.RequireDigit = true;
    opt.Lockout.MaxFailedAccessAttempts = 1;

    opt.Password.RequireLowercase = true;
    opt.Password.RequiredLength = 8;
    opt.Password.RequireDigit = true;
    opt.Lockout.MaxFailedAccessAttempts = 1;

    opt.Password.RequireNonAlphanumeric = true;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);

}).AddDefaultTokenProviders().AddEntityFrameworkStores<AtesgahDbContext>();

builder.Services.AddDbContext<AtesgahDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSql"));
});
builder.Services.AddAutoMapper();
builder.Services.AddRepositories();
builder.Services.AddService();
var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        c =>
        {
            c.EnablePersistAuthorization();
        }

    );
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();