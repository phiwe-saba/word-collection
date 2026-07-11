using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Debugging;
using word_collection.Data;
using word_collection.Orchestration.Implementation;
using word_collection.Orchestration.Interface;
using word_collection.Repository.Implementation;
using word_collection.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration) 
    .CreateLogger();

builder.Host.UseSerilog();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<WordCollectionDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("wordcollection"));
});

builder.Services.AddScoped<IWordCollectionOrchestration, WordCollectionOrchestration>();
builder.Services.AddScoped<IWordCollectionRepository, WordCollectionRepository>();

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
