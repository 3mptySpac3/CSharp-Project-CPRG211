using Microsoft.AspNetCore.Components.WebView.Maui;
using JPsShopz.Data;
using JPsShopz.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using JPsShopz.Authenticate;
using JPsShopz.Data;
using System.Reflection;

namespace JPsShopz
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            string basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            builder.Services.AddSingleton<IConfiguration>(configuration);

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "JPsShopz.db3");
            builder.Services.AddSingleton(new Database(dbPath));
            builder.Services.AddScoped<UserAuthenticationService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif

            builder.Services.AddScoped<CartService>();

            builder.Services.AddAuthorizationCore();

            return builder.Build();
        }
    }
}
