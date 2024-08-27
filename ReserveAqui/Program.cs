using ReserveAqui.Config;
using Microsoft.EntityFrameworkCore;
using ReserveAqui.Services.Administrador;
using ReserveAqui.Services.Instituicao;
using ReserveAqui.Services.Professor;
using ReserveAqui.Services.Material;
using ReserveAqui.Services.Sala;
using ReserveAqui.Services.ReservaSala;
using ReserveAqui.Services.ReservaMaterial;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAdministradorService, AdministradorService>();
builder.Services.AddScoped<IInstituicaoService, InstituicaoService>();
builder.Services.AddScoped<IProfessorService, ProfessorService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<ISalaService, SalaService>();
builder.Services.AddScoped<IReservaSalaService, ReservaSalaService>();
builder.Services.AddScoped<IReservaMaterialService, ReservaMaterialService>();

string sqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(sqlConnection, ServerVersion.AutoDetect(sqlConnection)));

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
