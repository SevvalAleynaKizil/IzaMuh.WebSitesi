
using Business.Containers;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddFluentValidation();
builder.Services.MyServiceInstance();
builder.Services.AddAuthentication("Cookies").AddCookie(x =>
{
    x.LoginPath = "/Admin/Giris";
    x.LogoutPath = "/Admin/Cikis";
    x.AccessDeniedPath = "/Admin/Giris";

});


var app = builder.Build();


app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(x => x.MapDefaultControllerRoute());
app.UseEndpoints(endpoints =>
{
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
          name: "areas",
          pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
        );
    });
});
app.Run();