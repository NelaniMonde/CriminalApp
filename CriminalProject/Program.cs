using CriminalProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CriminalProject.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using CriminalProject.UserActivityClasses;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the container.  
builder.Services.AddControllersWithViews();

//Configuring Razor Pages
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

//Configuring Data context Service
builder.Services.AddDbContext<CriminalAppContext>(options => options.UseSqlServer(builder.Configuration.
    GetConnectionString("DefaultConnection")));

/*options => options.SignIn.RequireConfirmedAccount = true*/
//builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<CriminalAppContext>();
//builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<CriminalAppContext>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<CriminalAppContext>().AddDefaultTokenProviders();

//Adding razor pages servies in the application
builder.Services.AddRazorPages();

builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Services.AddScoped<IUserActivityLogger, UserActivityLogger>();
 
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
app.UseAuthentication();
app.UseAuthorization();

//Routing to Razor Pages
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
