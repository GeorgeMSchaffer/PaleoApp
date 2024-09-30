using System.Reflection;
using Backend;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Logging;
using Shared.Models;
using Backend.Services;
using AutoMapper;
using Shared.Entities;
using Backend.Services;
using Backend.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IntervalService>();
builder.Services.AddScoped<OccurrenceService>();
builder.Services.AddScoped<SpeciesService>();
builder.Services.AddScoped<TaxaService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//builder.Services.AddScoped<ILogger>();

var app = builder.Build();
//[TODO:] See if its better to store in here or a seperate profile files
var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<Interval, IntervalDTO>();
    cfg.CreateMap<Occurrence, OccurrenceDTO>();
    cfg.CreateMap<Species, SpeciesDTO>();
    cfg.CreateMap<Taxa, TaxaDTO>();
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();

}


app.UseExceptionHandler("/Error");
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();