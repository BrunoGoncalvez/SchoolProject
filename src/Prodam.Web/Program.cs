using Microsoft.EntityFrameworkCore;
using Prodam.Core.Interfaces;
using Prodam.Data.Context;
using Prodam.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddDbContext<EntitiesContext>(options => options.UseInMemoryDatabase("DefaultDatabase"));

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
