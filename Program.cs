using Microsoft.EntityFrameworkCore;
using WebAppGlobal.Models;
using WebAppGlobal.Repositories;
using WebAppGlobal.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<WebAppGlobalDbContext>(options =>
{
    options.UseOracle(
        builder.Configuration["ConnectionStrings:WebAppGlobal"]);
});

builder.Services.AddScoped<IVagaRepository, VagaRepository>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<IEstacionamentoRepository, EstacionamentoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();
