using API_Oficina.Persistence;
using API_Oficina.Application;
using Microsoft.EntityFrameworkCore;
using API_Oficina.Adapters;

var builder = WebApplication.CreateBuilder(args);

// Configurar conexão com o banco de dados
var connectionString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddDbContext<OficinaContext>(opt =>
    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Adicionar Controllers
builder.Services.AddControllers();

// Adicionar Swagger para documentação da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar Repositories
builder.Services.AddScoped<IWorkRepository, WorkRepository>();
builder.Services.AddScoped<IWorkTypeRepository, WorkTypeRepository>();
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IBuyedMaterialRepository, BuyedMaterialRepository>();

// Registrar Services
builder.Services.AddScoped<IWorkService, WorkService>();
builder.Services.AddScoped<IWorkTypeService, WorkTypeService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IBuyedMaterialService, BuyedMaterialService>();

var app = builder.Build();

// Configurar Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();