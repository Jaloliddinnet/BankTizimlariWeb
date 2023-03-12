using BankTizimlari.Servise.IServices;
using BankTizimlari.Servise.Services;
using BankTizimlari.Servises.Extention;
using BankTIzimlati.Data.BankDBContexts;
using BankTIzimlati.Data.IRepositories;
using BankTIzimlati.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AppDbConTextes(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddService();
builder.Services.AddRepositories();
builder.Services.AddConfigurationIdentity();
builder.Services.AddConfigurationJwt(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddSwaggerConfiguration();

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
