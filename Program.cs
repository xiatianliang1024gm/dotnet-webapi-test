using Microsoft.EntityFrameworkCore;
using webapi_test.Data;
using webapi_test.Models;
using webapi_test.Services;

var builder = WebApplication.CreateBuilder(args);

var appConfig = builder.Configuration;
var dbConnectionStr = appConfig.GetConnectionString("DBConnect");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

// db context
builder.Services.AddDbContext<IdentifierContext>(options =>
{
    options.UseSqlite(
        dbConnectionStr
    );
});

// repository
builder.Services.AddScoped<BookRepository>();

// services
builder.Services.AddScoped<BookService>();

// controllers
builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
