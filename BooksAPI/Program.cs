using BusinessLogicLayer.IServices;
using BusinessLogicLayer.Services;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repasitories;
using DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<ICategoryInterface, CategoryRepasitory>();
builder.Services.AddScoped<IBookInterface, BookRepasitory>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

#region DI service
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
#endregion

// Swagger Qo'llab-quvvatlash uchun
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Swagger uchun to'g'ri sozlash
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        options.RoutePrefix = string.Empty; // Swagger UI-ni root (https://localhost:xxxx) da ochish
    });
}

app.UseHttpsRedirection();  // Https'ga o'tish
app.UseAuthorization();

app.MapControllers();

app.Run();


































//using BusinessLogicLayer.IServices;
//using BusinessLogicLayer.Services;
//using DataAccessLayer.Data;
//using DataAccessLayer.Entities;
//using DataAccessLayer.Interfaces;
//using DataAccessLayer.Repasitories;
//using DTOs;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

//builder.Services.AddScoped<ICategoryInterface, CategoryRepasitory>();
//builder.Services.AddScoped<IBookInterface, BookRepasitory>();
//builder.Services.AddScoped<ICategoryService, CategoryService>();
//builder.Services.AddScoped<IBookService, BookService>();
//builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//#region DI service
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddIdentity<User, IdentityRole>()
//    .AddEntityFrameworkStores<AppDbContext>()
//    .AddDefaultTokenProviders();
//#endregion 

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
