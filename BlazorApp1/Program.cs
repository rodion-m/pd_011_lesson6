using System.Text;
using BlazorApp1.Data;
using BlazorApp1.Services;
using Microsoft.EntityFrameworkCore;

Console.OutputEncoding = Encoding.UTF8;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<SmtpCredentials>(
    builder.Configuration.GetSection("SmtpCredentials"));
// Add services to the container.
builder.Services.AddSingleton<IEmailSender, SmtpEmailSender>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var dbPath = "myapp.db";
builder.Services.AddDbContext<AppDbContext>(
    options => options
        .UseSqlite($"Data Source={dbPath}")
        .EnableDetailedErrors()
        .EnableSensitiveDataLogging()
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();