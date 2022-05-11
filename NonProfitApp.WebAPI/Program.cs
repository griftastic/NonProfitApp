using NonProfitApp.Data;
using Microsoft.EntityFrameworkCore;
using NonProfitApp.Services.User;
using NonProfitApp.Services.Token;
using NonProfitApp.Services.Note;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add connection string and DbContext setup
services.AddDbContext<ApplicationDbContext>(options =>
         options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
         builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));


// Add User Service/Interface for Dependency Injection Here
builder.Services.AddScoped<IUserService, UserService>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();