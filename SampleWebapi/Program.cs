using Microsoft.EntityFrameworkCore;
using SampleWebapi.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(
//        name: "AllowOrigin",
//        builder =>
//        {
//            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
//        });
//});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmployeeDbContext>(options => 
  options.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(c=> c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
