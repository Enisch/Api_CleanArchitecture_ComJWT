
using Microsoft.EntityFrameworkCore;
using MigrationDto_e_Token.Controllers;
using Usuario.Infra.Ioc;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


/*var conexão = builder.Configuration.GetConnectionString("DefaultString");
builder.Services.AddDbContext<usuario.Infra.Data.Context.ContextDb>(op => op.UseMySql(conexão, ServerVersion.AutoDetect(conexão)));*/

builder.Services.Infrastructure(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
