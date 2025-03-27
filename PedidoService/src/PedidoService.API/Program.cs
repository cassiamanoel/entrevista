using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using PedidoService.Application.Interfaces;
using PedidoService.Domain.Interfaces;
using PedidoService.Infrastructure.Data;
using PedidoService.Infrastructure.Integrations;
using PedidoService.Infrastructure.Repositories;
using PedidoService.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<PedidoDbContext>(options =>
    //options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));
builder.Services.AddDbContext<PedidoDbContext>(options =>
    options.UseInMemoryDatabase("PedidosDb"));

builder.Services.AddScoped<IPedidoAppService, PedidoAppService>();
builder.Services.AddScoped<IPedidoService, PedidoService.Application.Services.PedidoService>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IFeatureFlagService, FeatureFlagService>();

builder.Services.AddHttpClient<ISistemaBClient, SistemaBClient>(client =>
{
    client.BaseAddress = new Uri("https://sistema-b.exemplo.com");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();