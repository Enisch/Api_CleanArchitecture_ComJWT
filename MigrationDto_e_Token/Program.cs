
using Microsoft.EntityFrameworkCore;
using MigrationDto_e_Token.Controllers;
using usuario.Infra.Data.Repositories;
using Usuario.Infra.Ioc;
using usuarioaplication.Domain.InterfacesParaRepositorio;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//

/*var conex�o = builder.Configuration.GetConnectionString("DefaultString");
builder.Services.AddDbContext<usuario.Infra.Data.Context.ContextDb>(op => op.UseMySql(conex�o, ServerVersion.AutoDetect(conex�o)));*/




builder.Services.Infrastructure(builder.Configuration);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.JwtToken();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
