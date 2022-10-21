using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SmartBoxContextConnection") ?? throw new InvalidOperationException("Connection string 'SmartBoxContextConnection' not found.");

builder.Services.AddDbContext<SmartBoxContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<SmartBoxContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

// aggiunge razor page login
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

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
app.UseAuthentication(); //auth

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=SmartBox}/{action=Index}/{id?}");

app.MapRazorPages(); // riga 7

app.Run();
