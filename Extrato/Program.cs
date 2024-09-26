using Extrato.Infrastructure;
using Extrato.Infrastructure.Repositories;
using Extrato.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//configure Fake context 
builder.Services.AddSingleton<FakeContext>();
//configure InMemory context 
builder.Services.AddDbContext<ExtratoDbContext>(db => db.UseInMemoryDatabase("ExtratoDb"));
// Repository
builder.Services.AddScoped<IBankRecordRepository, BankRecordRepository>();
// Services
builder.Services.AddScoped<BankRecordService>();
builder.Services.AddScoped<PDFService>();

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
