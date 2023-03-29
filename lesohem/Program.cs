using lesohem.DataBase;
using lesohem.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(op =>
{
    op.AccessDeniedPath = "/Home/Index";
});
builder.Services.AddAuthorization();
builder.Services.AddDbContext<LesohemContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnetction")));
builder.Services.AddTransient<ISocMedia, SocMedia>();
builder.Services.AddScoped<IInfoProfile, InfoProfile>();
builder.Services.AddScoped<IFiles, Files>();
builder.Services.AddMemoryCache();

var app = builder.Build();
app.UseRouting();
app.UseStaticFiles();
app.UseDefaultFiles();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
            name: "MyArea",
            pattern: "{area:exists}/{controller=Profile}/{action=Profile}/{id?}"
        );
    endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
        );
});

app.Run();

public partial class Test
{
    public int Id { get; set; }
    public string? Mname { get; set; }
    public string? Link { get; set; }
    public int? PersonId { get; set; }
}