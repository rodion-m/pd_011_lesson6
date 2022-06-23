using System.Text;
using RazorPagesPD011.BackgroundServices;
using RazorPagesPD011.Controllers;
using RazorPagesPD011.Models;
using RazorPagesPD011.Services;
using Serilog;

Console.OutputEncoding = Encoding.UTF8;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<SmtpCredentials>(
    builder.Configuration.GetSection("SmtpCredentials"));
builder.Services.AddSingleton<ICatalog, InMemoryCatalog>();
builder.Services.AddSingleton<IEmailSender, SmtpEmailSender>();
builder.Services.AddHostedService<ServerStartingNotifier>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Host.UseSerilog((_, conf) => conf.WriteTo.Console());

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

//app.UseSerilogRequestLogging();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
