using BookStoreApp.API.Configurations;
using BookStoreApp.API.Data;
using BookStoreApp.API.Endpoints.Internal;
using BookStoreApp.API.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpoints<Program>(builder.Configuration);

//builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddDbContext<BookStoreDbContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("BookStoreAppDbConnection")));

builder.Services.AddIdentityCore<ApiUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<BookStoreDbContext>();

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Host.UseSerilog((ctx, lc) => 
    lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddCors( options => {
    options.AddPolicy("AllowAll", 
        b => b.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin());
});

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseEndpoints<Program>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.Run();
