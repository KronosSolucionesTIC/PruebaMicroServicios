using AutoMapper;
using Microservicios_bl;
using Microservicios_dal;
using Microsoft.EntityFrameworkCore;
using PruebaMicroservicios.Automapper;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region Inyeccion de dependecias para Interfaces
builder.Services.AddScoped<IClienteDal, ClienteDal>();
builder.Services.AddScoped<IClienteBl, ClienteBl>();
builder.Services.AddScoped<ICuentaDal, CuentaDal>();
builder.Services.AddScoped<ICuentaBl, CuentaBl>();
builder.Services.AddScoped<IMovimientoDal, MovimientoDal>();
builder.Services.AddScoped<IMovimientoBl, MovimientoBl>();
#endregion

#region Mapper
var MapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfileMasterModule());
});

IMapper mapper = MapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Datacontext
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);

//Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(myAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();