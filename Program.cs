using E_LEARNING_SE_102_PROJECT.Data;
using E_LEARNING_SE_102_PROJECT.Services.DbInitializer;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using E_LEARNING_SE_102_PROJECT.Models;
using E_LEARNING_SE_102_PROJECT.Utilities.EmailSender;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Register db context
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DevConnection")
    ));

//Register the identity with application user and identity role
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


//Register the db initializer
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
//Register the email sender
builder.Services.AddScoped<IEmailSender, EmailsSender>();
//Register Razor pages
builder.Services.AddRazorPages();

//Build the application
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Learner}/{controller=Home}/{action=Index}/{id?}");

//Call the function
SeedDatabase();

//app.MapRazorPages();
app.Run();

//Function to seed and start database
void SeedDatabase(){

    using(var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }
 }