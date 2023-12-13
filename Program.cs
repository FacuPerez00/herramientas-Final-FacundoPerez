using Proyecto.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proyecto.Data;
using Microsoft.AspNetCore.Authorization;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EmpleadosPuestosContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("EmpleadosPuestosContext") ?? throw new InvalidOperationException("Connection string 'EmpleadosPuestosContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<EmpleadosPuestosContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<ISectorService, SectorService>();
builder.Services.AddScoped<IPuestoService, PuestoService>();

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
