using FileUpload.Data;
using FileUploadOperation.Controllers;
using FileUploadOperation.Interfaces;
using FileUploadOperation.Repositary;
using FileUploadOperation.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<ApplicationDBContext>
(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection1")));

builder.Services.AddScoped<Idetails, Authentication>();
builder.Services.AddScoped<IfileUpload, Authentication1>();
builder.Services.AddScoped<ITourRepositary,TourRepositary>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddSession(Options =>
{
    Options.IdleTimeout = TimeSpan.FromMinutes(30);
    Options.Cookie.HttpOnly = true;
    Options.Cookie.IsEssential = true;
});
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
    pattern: "{controller=Account}/{action=LoginPage}/{id?}");


app.Run();
