namespace Astropage
{
    using Microsoft.AspNetCore.Authentication.Cookies;
    public class Program
    {
        public static void Main(string[] args)

        {


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Lägg till stöd för loginfunktionen. OBS LoginPath!
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options => { options.LoginPath = "/Webbsida/Index/"; });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            // Lägg till stöd för loginfunktionen. OBS FÖRE Authorization i koden
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}