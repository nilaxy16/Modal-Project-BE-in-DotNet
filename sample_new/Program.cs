using DataAccess.Data;
using DataAccess.Interface;
using DataAccess.Model;
using DataAccess.Repository;
using LogicalLayer;
using LogicalLayer.ResponseModal;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Modal_Project.Controllers;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StudentAPIDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ContactAPIConnectionString")));

builder.Services.AddScoped<IRepository, StudentRepository>();
builder.Services.AddScoped<IService, StudentService>();

builder.Services.AddScoped<DRepository<Department>, DepartmentRepository>();
builder.Services.AddScoped<DService<Department>, DepartmentService>();

builder.Services.AddScoped<CRepository, CourseRepository>();
builder.Services.AddScoped<CService, CourseService>();

builder.Services.AddScoped<ARepository, AuthRepository>();
builder.Services.AddScoped<AService, AuthService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularOrigins",
    builder =>
    {
        builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("veryscerettoken.....")),
        ValidateAudience = false,
        ValidateIssuer = false
    };
});



var app = builder.Build();

app.UseCors("AllowAngularOrigins");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
