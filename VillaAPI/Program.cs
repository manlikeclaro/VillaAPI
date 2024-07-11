using Microsoft.EntityFrameworkCore;
using VillaAPI;
using VillaAPI.Data;
using VillaAPI.Repository;
using VillaAPI.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add controllers with Newtonsoft.Json support
builder.Services.AddControllers().AddNewtonsoftJson();

// Add scoped service for IVillaRepository
builder.Services.AddScoped<IVillaRepository, VillaRepository>();

// Add scoped service for IVillaNumberRepository
builder.Services.AddScoped<IVillaNumberRepository, VillaNumberRepository>();

// Add AutoMapper with MappingConfig
builder.Services.AddAutoMapper(typeof(MappingConfig));

// Add ApplicationDbContext with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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